using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Application.ServiceImp
{
    public class TokenGenerator : ITokenGenerator
    {
        protected readonly IConfiguration _config;
       
        public TokenGenerator(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string LoginTokenGenerator(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
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

        public string? ValidateVerificationToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);


            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _config["Jwt:Issuer"],
                    ValidAudience = _config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)

                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var emailClaim1 = jwtToken.Claims.FirstOrDefault(x =>x.Type == ClaimTypes.Email || x.Type  == "email");
                
                var purposeClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "purpose");
                

                if (purposeClaim?.Value != "email_verification")
                    return null;

                return emailClaim1?.Value;
            }
            catch
            {
                return null;
            }

            //try
            //{
            //    tokenHandler.ValidateToken(token, new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = _config["Jwt:Issuer"],
            //        ValidAudience = _config["Jwt:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(key)
            //    }, out SecurityToken validatedToken);
            //    var jwtToken = (JwtSecurityToken)validatedToken;
            //    var emailClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            //    var purposeClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "purpose");
            //    return emailClaim?.Value;
            //}
            //catch
            //{
            //    return null;
            //}
        }

        public string VerificationTokenGenerator(User user)
        {
       
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("purpose", "email_verification")
            }),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
            //// Token oluşturma işlemleri burada yapılacak
            //var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            //var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            //var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            //{
            //    Subject = new System.Security.Claims.ClaimsIdentity(new[]
            //    {
            //        new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, user.Email),
            //        new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, user.Id.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddHours(1),
            //    Issuer = _config["Jwt:Issuer"],
            //    Audience = _config["Jwt:Audience"],
            //    SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
            //        new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key), Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //return tokenHandler.WriteToken(token);

        }
    }
}
