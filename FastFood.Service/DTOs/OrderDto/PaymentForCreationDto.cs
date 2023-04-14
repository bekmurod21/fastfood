using FastFood.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.OrderDto
{
    public class PaymentForCreationDto
    {
        [Required]
        public decimal PaidPrice { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        [Required]
        public long OrderId { get; set; }
    }
}
