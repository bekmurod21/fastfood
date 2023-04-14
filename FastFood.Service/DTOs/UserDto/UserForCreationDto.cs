using FastFood.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.UserDto
{
    public class UserForCreationDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public UserRole Role { get; set; }
    }
}
