using System.ComponentModel.DataAnnotations;

namespace PetStore.Authorization.Data.DTO
{
    public class LoginUserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}
