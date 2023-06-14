using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Entities.Users;
using FastFood.Domain.Enums;
using FastFood.Service.DTOs.OrderDto;
using FastFood.Service.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Service.DTOs.PaymentDto
{
    public class PaymentForResultDto
    {
        public decimal? Amount { get; set; }
        public string Description { get; set; }
        public PaymentStatus Status { get; set; }
        public bool IsAdmin { get; set; }

        public long UserId { get; set; }
        public UserForResultDto User { get; set; }

        public long OrderId { get; set; }
        public OrderForResultDto Order { get; set; }
    }
}
