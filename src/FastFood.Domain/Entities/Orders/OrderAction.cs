using FastFood.Domain.Commons;
using FastFood.Domain.Enums;

namespace FastFood.Domain.Entities.Orders
{
    public class OrderAction:Auditable
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? ApproximateFinishTime { get; set; }
    }
}
