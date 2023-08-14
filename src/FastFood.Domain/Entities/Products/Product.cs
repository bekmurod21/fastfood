using FastFood.Domain.Commons;
using FastFood.Domain.Entities.Orders;
using System.Text.Json.Serialization;

namespace FastFood.Domain.Entities.Products
{
    public class Product : Auditable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public long CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        [JsonIgnore]
        public ICollection<OrderItem> OrderItems { get; set; }
    }

}
