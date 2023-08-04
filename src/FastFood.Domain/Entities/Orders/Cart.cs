using FastFood.Domain.Commons;

namespace FastFood.Domain.Entities.Orders
{
    public class Cart:Auditable
    {
        public long UserId { get; set; }
        public ICollection<CartItem> Items { get; set; }
    }
}
