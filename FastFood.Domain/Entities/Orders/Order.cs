
﻿using FastFood.Domain.Commons;


namespace FastFood.Domain.Entities.Order
{
    public class Order : Auditable
    {
        public long UserId { get; set; }
        public long? PaymentId { get; set; } = null;
        public List<OrderProduct> Items { get; set; }
        public bool IsPaid { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Unpaid;
        public decimal TotalAmount { get; set; }
    }
}
