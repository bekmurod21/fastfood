using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.ProductDto;
using FastFood.Service.Interfaces.Products;

namespace FastFood.WebApi.Controllers.Products
{
    public class ProductsController : RestfulSense
    {
        private readonly IProductService service;

        public ProductsController(IProductService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async ValueTask<IActionResult> PostAsync(ProductForCreationDto dto)
        {
            return Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await service.AddAsync(dto)
            });
        }
        [HttpPut]
        public async ValueTask<IActionResult> PutAsync(long id, ProductForUpdateDto dto)
        {
            return Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await service.ModifyAsync(id, dto)
            });
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long id) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await service.RemoveAsync(id)
            });
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetByIdAsync(long id) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await service.RetrieveAsync(id)
            });
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await service.RetrieveAllAsync(@params)
            });
    }
}
