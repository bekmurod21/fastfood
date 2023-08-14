using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using FastFood.Service.DTOs.CartDto;
using FastFood.Domain.Configurations;
using FastFood.Service.Interfaces.Order;

namespace FastFood.WebApi.Controllers.Orders
{
    public class CartsController : RestfulSense
    {
        private readonly ICartService service;

        public CartsController(ICartService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async ValueTask<IActionResult> PostAsync([FromBody] CartItemForCreationDto dto) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Succcess",
                Data = await this.service.AddAsync(dto)
            });
        [HttpPut]
        public async ValueTask<IActionResult> PutAsync(CartItemForUpdateDto dto) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.ModifyAsync(dto)
            });
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(long id) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.RemoveAsync(id)
            });
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.RetrieveAllAsync(@params)
            });
        [HttpGet("id")]
        public async ValueTask<IActionResult> GetByIdAsync(long id) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.RetrieveByIdAsync(id)
            });
        [HttpGet("get-clientid")]
        public async ValueTask<IActionResult> GetByClientIdAsync() =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.RetrieveByClientIdAsync()
            });
    }
}
