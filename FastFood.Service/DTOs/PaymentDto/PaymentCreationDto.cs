using FastFood.Domain.Enums;

namespace FastFood.Service.DTOs.PaymentDto
{
    public class PaymentCreationDto
    {
        public long OrderId { get; set; }
        public PaymentStatus Status { get; set; }
        public decimal Amount { get; set; }
    }
}
