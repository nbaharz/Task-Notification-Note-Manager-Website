using GradProj.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Application.DTO
{
    public class LoginDto : User //login 
    {

        public Guid UserId { get; set; }
        public required string Email { get; set; }    
        public required string  Password { get; set; }

        public string Role { get; set; }

    }
}
