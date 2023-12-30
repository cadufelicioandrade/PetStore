using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace PetStore.AuthAPI.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LogoutUser()
        {
            var resultIdentity = _signInManager.SignOutAsync();

            if (resultIdentity.IsCompletedSuccessfully)
                return Result.Ok();

            return Result.Fail("Failed logout.");
        }

    }
}
