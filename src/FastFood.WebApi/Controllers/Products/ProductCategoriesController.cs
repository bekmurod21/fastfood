using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.ProductDto;
using FastFood.Service.Interfaces.Products;
using Microsoft.AspNetCore.Authorization;

namespace FastFood.WebApi.Controllers.Products
{

    public class ProductCategoriesController : RestfulSense
    {
        private readonly IProductCategoryService productCategoryService;
        public ProductCategoriesController(IProductCategoryService productCategory)
        {
            this.productCategoryService = productCategory;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("product-category")]
        public async ValueTask<IActionResult> PostAsync(ProductCategoryForCreationDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "Ok",
                Data = await this.productCategoryService.AddAsync(dto)
            });
        [Authorize(Roles = "Admin")]
        [HttpPut("product-category")]
        public async ValueTask<IActionResult> PutAsync([FromQuery] long id, ProductCategoryForUpdateDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "Ok",
                Data = await this.productCategoryService.ModifyAsync(id, dto)
            });
        [Authorize(Roles = "Admin")]
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
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(new Response
            {
                Code = 200,
                Message = "Ok",
                Data = await this.productCategoryService.RetrieveAllAsync(@params)
            });
    }
}
