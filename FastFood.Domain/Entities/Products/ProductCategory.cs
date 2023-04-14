using FastFood.Domain.Commons;

namespace FastFood.Domain.Entities.Product;

public class ProductCategory:Auditable
{
    public string Name { get; set; }
}
