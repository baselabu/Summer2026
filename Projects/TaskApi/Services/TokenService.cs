using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace TaskApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(string username)
        {
            var jwtKey = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key is missing.");
            var jwtIssuer = _configuration["Jwt:Issuer"];
            var jwtAudience = _configuration["Jwt:Audience"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var JwtClaims = new[]
            {
                new Claim(ClaimTypes.Name, username),
            };
            var token = new JwtSecurityToken(

                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: JwtClaims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );
            var TokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return TokenString;
        }        
        
    }
}