using PetStore.Web.Extensions;
using PetStore.Web.Models;
using PetStore.Web.Services.Interfaces;
using System.Reflection;

namespace PetStore.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "api/authorization";

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> CreateUser(AuthModel authModel)
        {
            //cadastro
            var response = await _httpClient.PostAsJsonAsync($"{BasePath}/cadastro", authModel);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<string>();
            else 
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<string> LoginUser(AuthModel authModel)
        {
            //login
            var response = await _httpClient.PostAsJsonAsync($"{BasePath}/login", authModel);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<string>();
            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> LogoutUser()
        {
            //logout
            var response = await _httpClient.GetAsync($"{BasePath}/logout");
            return await response.ReadContentAs<bool>();
        }
    }
}
