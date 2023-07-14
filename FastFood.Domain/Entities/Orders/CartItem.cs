using FastFood.Domain.Commons;
using FastFood.Domain.Entities.Products;

namespace FastFood.Domain.Entities.Orders
{
    public class CartItem:Auditable
    {
        public long CartId { get; set; }
        public Cart Cart { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public int Amount { get; set; }
        public decimal AmountTotal { get; set; }
        public bool IsOrdered { get; set; }
    }
}
