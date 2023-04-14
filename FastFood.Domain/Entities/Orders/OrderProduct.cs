using FastFood.Domain.Commons;
using FastFood.Domain.Entities.Products;

namespace FastFood.Domain.Entities.Orders;
public class OrderProduct:Auditable
{
    public int Quatity { get; set; }

    public long CategoryId { get; set; }
    public ProductCategory Category { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}
