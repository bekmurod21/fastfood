using FastFood.Domain.Commons;
using FastFood.Domain.Entities.Products;

namespace FastFood.Domain.Entities.Orders;
public class OrderProduct:Auditable
{
    public long OrderId { get; set; }
    public long ProductId { get; set; }
}
