
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.DTO;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;
using GradProj.Application.JwtToken;

namespace GradProj.Application.ServiceImp
{
    public class UserService : GenericService<User>, IUserService
    {
        protected readonly IUserRepository _userRepository; //bu amk reposu servis entitisinin tipinde olmak zorunda
        private readonly IGenerateToken _tokenGenerator;
        public UserService(IUserRepository repository, IGenerateToken generateToken) : base(repository)
        {
            _userRepository = repository;
            _tokenGenerator = generateToken;
        }

        public LoginDto AuthUser(string email, string password)
        {
            var checkuser = _repository.GetSingleAsync(x=> x.Email == email && x.Password == password).FirstOrDefault();

            if (checkuser==null)
            {
                throw new Exception("There is not such a User");
                
            }
            return new LoginDto
            {
                UserId = checkuser.Id,
                Email = checkuser.Email,
                Password = checkuser.Password,
                Token = _tokenGenerator.GenerateTokenMethod(checkuser),
            };
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
                    Role = "User"
                };
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