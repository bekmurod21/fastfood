using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Service.DTOs.ProductDto
{
    public class ProductForViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public long CategoryId { get; set; }
        public IFormFile File { get; set; }

    }
}
