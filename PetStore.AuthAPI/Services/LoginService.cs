using FluentResults;
using Microsoft.AspNetCore.Identity;
using PetStore.AuthAPI.Data.Request;
using PetStore.AuthAPI.Models;

namespace PetStore.AuthAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LoginUser(LoginRequest request)
        {
            var resultIdentity = _signInManager
                                    .PasswordSignInAsync(request.Username, request.Password, false, false);

            if(resultIdentity.Result.Succeeded)
            {
                IdentityUser<int> userIdentity = _signInManager.UserManager.Users
                                                        .FirstOrDefault(u => u.NormalizedUserName.Equals(request.Username.ToUpper()));

                Token token = _tokenService.CreateToken(userIdentity);

                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("failed to create token");
        }
    }
}
