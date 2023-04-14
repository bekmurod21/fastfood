using FastFood.Domain.Commons;
using FastFood.Domain.Enums;

namespace FastFood.Domain.Entities.Order
{
    public class Payment : Auditable
    {
        public decimal PaidPrice { get; set; }
        public PaymentType PaymentType { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
