using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Service.DTOs.OrderDto
{
    public class OrderForResultDto
    {
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public long AddressId { get; set; }
        public long UserId { get; set; }

        public ICollection<OrderProductForCreationDto> OrderProducts { get; set; }
    }
}
