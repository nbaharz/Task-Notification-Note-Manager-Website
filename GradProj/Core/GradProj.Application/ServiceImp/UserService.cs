
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

        public UserService(IUserRepository repository, IConfiguration configuration) : base(repository)
        {
            _userRepository = repository;
            _config = configuration;    

        }

        public async  Task<string?> AuthUser(string email, string password)
        {
            var checkuser = _repository.GetSingleAsync(x=> x.Email == email && x.Password == password).FirstOrDefault();

            if (checkuser==null)
            {
                throw new Exception("There is not such a User");
                
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, checkuser.Email),
                new Claim(ClaimTypes.NameIdentifier, checkuser.Id.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);


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