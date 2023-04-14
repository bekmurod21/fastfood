using FastFood.Domain.Commons;
using FastFood.Domain.Entities.Product;

namespace FastFood.Domain.Entities.Order;
public class OrderProduct:Auditable
{
    public int Quatity { get; set; }

    public long CategoryId { get; set; }
    public ProductCategory Category { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}
