using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.UserDto
{
    public class UserForLoginDto
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
