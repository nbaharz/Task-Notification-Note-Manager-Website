
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.DTO;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace GradProj.Application.ServiceImp
{
    public class UserService : GenericService<User>, IUserService
    {
        protected readonly IUserRepository _userRepository; //bu amk reposu servis entitisinin tipinde olmak zorunda
        private readonly IConfiguration _config;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(IUserRepository repository, IConfiguration configuration, ITokenGenerator tokenGenerator) : base(repository)
        {
            _userRepository = repository;
            _config = configuration;
            _tokenGenerator = tokenGenerator;


        }

        public async  Task<string?> AuthUser(string email, string password)
        {
            var checkuser = _repository.GetSingleAsync(x=> x.Email == email && x.Password == password).FirstOrDefault();



            if (checkuser==null)
            {
                throw new Exception("There is not such a User");
                
            }

            if (!checkuser.IsVerified)
                throw new Exception("E-posta doğrulanmamış.");

            var token = _tokenGenerator.LoginTokenGenerator(checkuser);
            return token;


        }

        public RegisterDto RegisterUser(RegisterDto newuser)
        {

             
            var checkuser = _repository.GetSingleAsync(u => u.Email == newuser.Email).FirstOrDefault();
            if (checkuser == null)
            {
                var NewUser = new User
                {
                    Name = newuser.Name,
                    Surname = newuser.Surname,
                    Email = newuser.Email,
                    Password = newuser.Password,
                    Role = "User",
                   


                };
                var verificationToken = _tokenGenerator.VerificationTokenGenerator(NewUser);
                Console.WriteLine("Verification Token: " + verificationToken);
                _repository.AddAsync(NewUser);
                return newuser;
            }
            else {
                throw new Exception("This email has already signed in");
            }
         


        }


    }
}


// if repository that stated at GenericService is private u cant call _repository in order to use it u have to state it with protected