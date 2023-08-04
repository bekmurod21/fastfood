using FastFood.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.UserDto
{
    public class UserForCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
    }
}
