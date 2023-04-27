using FastFood.Domain.Commons;
using FastFood.Domain.Entities.Users;

namespace FastFood.Domain.Entities.Orders
{
    public class Order : Auditable
    {
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public long AddressId { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
  

    }
}
