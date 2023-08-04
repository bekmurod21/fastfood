using FastFood.Domain.Enums;
using FastFood.Domain.Commons;
using FastFood.Domain.Entities.Orders;

namespace FastFood.Domain.Entities.Users
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Role> Roles { get; set;}
        public ICollection<Order> Orders { get; set;}
    }
}
