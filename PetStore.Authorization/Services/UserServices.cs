using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PetStore.Authorization.Data.DTO;
using PetStore.Authorization.Enums;
using PetStore.Authorization.Models;

namespace PetStore.Authorization.Services
{
    public class UserServices
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenServices _tokenServices;
        private RoleManager<IdentityRole> _roleManager;
        private IMapper _mapper;

        public UserServices(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager, TokenServices tokenServices, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenServices = tokenServices;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateUser(CreateUserDTO dto, Roles role)
        {
            if (!(await _roleManager.RoleExistsAsync(role.ToString())))
                await _roleManager.CreateAsync(new IdentityRole(role.ToString()));

            User user = _mapper.Map<User>(dto);
            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

            user = _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedUserName == dto.Username.ToUpper());

            await _userManager.AddToRoleAsync(user, role.ToString());

            return result;
        }

        public async Task<string> Login(LoginUserDTO dto)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (result.Succeeded)
            {
                var user = _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedUserName == dto.Username.ToUpper());
                var token = await _tokenServices.GenerateToken(user);
                return token;
            }

            return String.Empty;
        }
    }
}
