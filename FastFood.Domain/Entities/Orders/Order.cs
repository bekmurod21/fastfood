
﻿using FastFood.Domain.Commons;


namespace FastFood.Domain.Entities.Order
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
