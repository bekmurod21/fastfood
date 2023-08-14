using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.ProductDto
{
    public class ProductCategoryForResultDto
    {
        public long Id { get; set; }

        [MinLength(3), MaxLength(200)]
        public string Name { get; set; }

        public ICollection<ProductForResultDto> Products { get; set; }
    }
}
