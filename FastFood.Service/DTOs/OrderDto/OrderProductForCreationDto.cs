using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.OrderDto
{
    public class OrderProductForCreationDto
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
    }
}
