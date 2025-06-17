using GradProj.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Application.JwtToken
{
    public interface IGenerateToken
    {
        public string GenerateTokenMethod(User user);
       
    }
}
