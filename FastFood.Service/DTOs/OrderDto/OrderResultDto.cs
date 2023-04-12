using FastFood.Domain.Entities;
using FastFood.Domain.Enums;

namespace FastFood.Service.DTOs.OrderDto
{
    public class OrderResultDto
    {
        public long UserId { get; set; }
        public long? PaymentId { get; set; } = null;
        public List<OrderItem> Items { get; set; }
        public bool IsPaid { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Unpaid;
        public decimal TotalAmount { get; set; }
    }
}
