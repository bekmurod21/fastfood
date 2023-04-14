using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.ProductDto
{
    public class CategoryForCreationDto
    {
        [Required]
        public string Name { get; set; }
    }
}
