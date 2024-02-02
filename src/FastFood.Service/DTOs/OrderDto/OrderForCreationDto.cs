using FastFood.Domain.Entities.Users;
using FastFood.Domain.Enums;

namespace FastFood.Service.DTOs.OrderDto
{
    public class OrderForCreationDto
    {
        public long AddressId { get; set; }
        public OrderStatus Status { get; set; }
    }
   
}
