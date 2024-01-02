using PetStore.Web.Models;
using System.Runtime.CompilerServices;

namespace PetStore.Web.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> CreateUser(AuthModel authModel);
        Task<string> LoginUser(AuthModel authModel);
        Task<bool> LogoutUser();
    }
}
