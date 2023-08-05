using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.ProductDto
{
    public class ProductCategoryForUpdateDto
    {
        [MinLength(3), MaxLength(200)]
        public string Name { get; set; }
    }
}
