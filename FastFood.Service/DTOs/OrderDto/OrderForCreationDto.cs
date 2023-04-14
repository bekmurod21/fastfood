using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Service.DTOs.OrderDto
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
