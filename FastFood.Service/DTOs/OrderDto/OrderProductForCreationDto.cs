using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.OrderDto
{
    public class OrderProductForCreationDto
    {
        [Required]
        public long Quatity { get; set; }

        [Required]
        public long CategoryId { get; set; }

        [Required]
        public long ProductId { get; set; }
    }
}
