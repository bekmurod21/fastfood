using FastFood.Domain.Commons;
using FastFood.Domain.Enums;

namespace FastFood.Domain.Entities.Order
{
    public class Payment : Auditable
    {
        public long OrderId { get; set; }
        public PaymentType Status { get; set; }
        public decimal Amount { get; set; }
    }
}
