using FastFood.Domain.Commons;
using FastFood.Domain.Entities.Users;
using FastFood.Domain.Enums;
using System.Text.Json.Serialization;

namespace FastFood.Domain.Entities.Orders
{
    public class Order : Auditable
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public long AddressId { get; set; }
        public Address Address { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; }
        [JsonIgnore]
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
