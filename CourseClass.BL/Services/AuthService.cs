using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CourseClass.BL.Contracts;
using CourseClass.BL.Domain;
using CourseClass.BL.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace CourseClass.BL.Services
{
    public class AuthService
    {
        private readonly IAdminRepository _repo;
        private readonly IConfiguration _config;
        public AuthService(IAdminRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }
        public object Authenticate(string email, string password)
        {
            Administrator admin = _repo.FindAdminByEmail(email);

            if (admin == null)
                throw new Exception("email doesn't exist");

            if (admin.Password != password)
                throw new Exception("Incorrect password");

            //TODO: Create token generator

            var response = new
            {
                admin.Id,
                Name = admin.Email,
                Email = admin.Name,
                Role = admin.Role.ToString(),
                Phone = admin.Phone,
                Token = GenerateJSONWebToken(admin)
            };

            return response;
        }

        private string GenerateJSONWebToken(Administrator userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Id", userinfo.Id.ToString()),
                new Claim("Role", userinfo.Role),
                new Claim(ClaimTypes.Email, userinfo.Email),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
    }
}