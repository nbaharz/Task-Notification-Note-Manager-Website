using GradProj.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Application.ServiceAbs
{
    public interface ITokenGenerator
    {
         string VerificationTokenGenerator(User user);
         string LoginTokenGenerator(User user);
        string? ValidateVerificationToken(string token);
    }
}
