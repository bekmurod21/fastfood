using FastFood.Domain.Commons;

namespace FastFood.Domain.Entities.Products;

public class ProductCategory:Auditable
{
    public string Name { get; set; }
}
