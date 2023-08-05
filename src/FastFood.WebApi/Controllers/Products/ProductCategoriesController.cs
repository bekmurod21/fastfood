using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.ProductDto;
using FastFood.Service.Interfaces.Products;

namespace FastFood.WebApi.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryService productCategoryService;
        public ProductCategoriesController(IProductCategoryService productCategory)
        {
            this.productCategoryService = productCategory;
        }

        [HttpPost("product-category")]
        public async ValueTask<IActionResult> PostAsync(ProductCategoryForCreationDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "Ok",
                Data = await this.productCategoryService.AddAsync(dto)
            });

        [HttpPut("product-category")]
        public async ValueTask<IActionResult> PutAsync([FromQuery] long id, ProductCategoryForUpdateDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "Ok",
                Data = await this.productCategoryService.ModifyAsync(id, dto)
            });

        [HttpDelete("product-category")]
        public async ValueTask<IActionResult> DeleteAsync([FromQuery] long id)
            => Ok(new Response
            {
                Code = 200,
                Message = "Ok",
                Data = await this.productCategoryService.RemoveAsync(id)
            });

        [HttpGet("product-category")]
        public async ValueTask<IActionResult> GetAsync([FromQuery] long id)
            => Ok(new Response
            {
                Code = 200,
                Message = "Ok",
                Data = await this.productCategoryService.RetrieveAsync(id)
            });

        [HttpGet("product-categories")]
        public async ValueTask<IActionResult> GetAsync([FromQuery] PaginationParams @params)
            => Ok(new Response
            {
                Code = 200,
                Message = "Ok",
                Data = await this.productCategoryService.RetrieveAllAsync(@params)
            });
    }
}
