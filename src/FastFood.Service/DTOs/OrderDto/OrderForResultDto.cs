using FastFood.Domain.Entities.Users;
using FastFood.Domain.Enums;
using FastFood.Service.DTOs.AddressDto;
using FastFood.Service.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Service.DTOs.OrderDto
{
    public class OrderForResultDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public UserForResultDto User { get; set; }
        public long AddressId { get; set; }
        public AddressForResultDto Address { get; set; }
        public OrderStatus Status { get; set; }

        public ICollection<OrderProductForCreationDto> OrderProducts { get; set; }
    }
}
