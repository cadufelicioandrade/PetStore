using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PetStore.AuthAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetStore.AuthAPI.Services
{
    public class TokenService
    {
        public TokenService()
        {
            
        }

        public Token CreateToken(IdentityUser<int> user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("893906d9d8fdcc738761f5d356870ad62480f2db"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                            claims: claims,
                            signingCredentials: credentials,
                            expires: DateTime.UtcNow.AddHours(1));

            var tokenstr = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenstr);
        }
    }
}
