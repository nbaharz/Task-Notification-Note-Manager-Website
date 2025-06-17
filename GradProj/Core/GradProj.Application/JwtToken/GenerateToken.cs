using GradProj.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Application.JwtToken
{
    public class GenerateToken : IGenerateToken
    {
        protected readonly JwtOptions _jwtOptions;
        public GenerateToken(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;   
        }
        public string GenerateTokenMethod(User user)
        {
            var creds = new SigningCredentials(_jwtOptions.Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: new[]
                {
                new Claim(ClaimTypes.Email, user.Email)
                },
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpireMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
