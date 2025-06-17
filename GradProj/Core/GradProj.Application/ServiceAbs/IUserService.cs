using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.DTO;
using GradProj.Domain.Entities;

namespace GradProj.Application.ServiceAbs
{
    public interface IUserService : IService<User>
    {
        RegisterDto RegisterUser(RegisterDto newuser);
        Task<string?> AuthUser( string email, string password);


    }
}
