﻿namespace FastFood.Service.DTOs.OrderDto
{
    public class OrderForCreationDto
    {
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public long AddressId { get; set; }
        public long UserId { get; set; }

        public ICollection<OrderProductForCreationDto> OrderProducts { get; set; }
    }
   
}
