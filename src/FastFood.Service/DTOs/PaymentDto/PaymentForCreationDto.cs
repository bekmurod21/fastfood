using FastFood.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.PaymentDto
{
    public class PaymentForCreationDto
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public long OrderId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
