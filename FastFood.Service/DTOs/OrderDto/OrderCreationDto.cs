using FastFood.Domain.Entities;
using FastFood.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Service.DTOs.OrderDto
{
     public class OrderCreationDto
    {
        public long UserId { get; set; }
        public long? PaymentId { get; set; } = null;
        public List<OrderItem> Items { get; set; }
        public bool IsPaid { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Unpaid;
        public decimal TotalAmount { get; set; }
    }
}
