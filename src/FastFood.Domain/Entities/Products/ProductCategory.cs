using FastFood.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Domain.Entities.Products
{
    public class ProductCategory:Auditable
    {
        [MinLength(3), MaxLength(200)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
