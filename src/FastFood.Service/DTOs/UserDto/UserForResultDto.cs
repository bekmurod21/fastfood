using FastFood.Domain.Enums;

namespace FastFood.Service.DTOs.UserDto
{
    public class UserForResultDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public long RoleId { get; set; }
    }
}
