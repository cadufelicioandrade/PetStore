using System.ComponentModel.DataAnnotations;

namespace PetStore.AuthAPI.Data.DTO
{
    public class CreateUserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
