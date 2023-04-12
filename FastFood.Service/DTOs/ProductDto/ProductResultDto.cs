using FastFood.Domain.Enums;

namespace FastFood.Service.DTOs.ProductDto
{
    public class ProductResultDto
    {
        public long OwnerId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductStatus Category { get; set; }
    }
}
