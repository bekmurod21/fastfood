using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.ProductDto
{
    public class ProductForCreationDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
    }
}
