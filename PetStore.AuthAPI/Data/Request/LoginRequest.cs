using System.ComponentModel.DataAnnotations;

namespace PetStore.AuthAPI.Data.Request
{
    public class LoginRequest
    {
        public LoginRequest()
        {
            
        }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
