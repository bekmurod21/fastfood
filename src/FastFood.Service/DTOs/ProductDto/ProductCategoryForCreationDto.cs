using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Service.DTOs.ProductDto
{
    public class ProductCategoryForCreationDto
    {
        [MinLength(3), MaxLength(200)]
        public string Name { get; set; }
    }
}
