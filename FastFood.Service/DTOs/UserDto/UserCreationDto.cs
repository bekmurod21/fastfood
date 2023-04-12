﻿using FastFood.Domain.Enums;

namespace FastFood.Service.DTOs.UserDto
{
    public class UserCreationDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public decimal AvailableMoney { get; set; }
    }
}
