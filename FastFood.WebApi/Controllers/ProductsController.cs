using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.ProductDto;
using FastFood.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;

        public ProductsController(IProductService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Create Product 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromBody]ProductForCreationDto product)=>
            Ok(await this.service.AddAsync(product));

        /// <summary>
        /// Remove product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteByIdAsync(long id)=>
            Ok(await this.service.RemoveAsync(id));

        /// <summary>
        /// Get all product
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public  IActionResult SelectAll([FromQuery] PaginationParams @params)=>
            Ok(this.service.RetrieveAll(@params));

        /// <summary>
        /// Get by id product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> SelectByIdAsync(long id) =>
            Ok(this.service.RetrieveAsync(id));

        [HttpPut("{id}")]
        public async ValueTask<IActionResult> ModifyById(long id,[FromBody] ProductForUpdateDto product) =>
            Ok(await this.service.ModifyAsync(id, product));
    }
}
