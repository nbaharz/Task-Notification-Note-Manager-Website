using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.ServiceAbs.Service;
using GradProj.Domain.Entities;

namespace GradProj.Application.Abstractions.Service
{
    public interface IUserService:IService<User>
    {
    }
}
