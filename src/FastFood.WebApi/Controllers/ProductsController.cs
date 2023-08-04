using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using FastFood.Service.Interfaces;
using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.ProductDto;

namespace FastFood.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
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
                Data = await this.service.AddAsync(dto)
            });
        }
        [HttpPut("id")]
        public async ValueTask<IActionResult> PutAsync(long id,ProductForUpdateDto dto)
        {
            return Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.ModifyAsync(id, dto)
            });
        }
        [HttpDelete("id")]
        public async ValueTask<IActionResult> DeleteAsync(long id) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.RemoveAsync(id)
            });
        [HttpGet("id")]
        public async ValueTask<IActionResult> GetByIdAsync(long id) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.RetrieveAsync(id)
            });
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.RetrieveAllAsync(@params)
            });
    }
}
