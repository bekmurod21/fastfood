using FastFood.Domain.Commons;
using FastFood.Domain.Entities.Orders.Feedbacks;
using FastFood.Domain.Entities.Payments;
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

        public long? PaymentId { get; set; }
        public Payment Payments { get; set; }
        public bool IsSaved { get; set; }
       // public decimal TotalAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentType PaymentType { get; set; }
        public OrderStatus Status { get; set; }
        [JsonIgnore]
        public ICollection<OrderItem> OrderItems { get; set; }
        [JsonIgnore]
        public ICollection<OrderAction> OrderActions { get; set; }
        [JsonIgnore]
        public ICollection<Feedback> Feedback { get; set; }
    }
}
