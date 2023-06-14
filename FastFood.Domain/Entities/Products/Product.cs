using FastFood.Domain.Commons;

namespace FastFood.Domain.Entities.Products
{
    public class Product : Auditable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
    }

}
