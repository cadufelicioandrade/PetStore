using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PetStore.Authorization.Data.DTO;
using PetStore.Authorization.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetStore.Authorization.Services
{
    public class TokenServices
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;

        public TokenServices(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<string> GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id),
                new Claim("email", user.Email)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("893906d9d8fdcc738761f5d356870ad62480f2db"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                                                expires: DateTime.Now.AddMinutes(20),
                                                claims: claims,
                                                signingCredentials: credentials);
            
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            
            return token;
        }
    }
}
