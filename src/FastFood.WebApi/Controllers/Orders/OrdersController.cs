using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.OrderDto;
using FastFood.Service.Interfaces.Orders;

namespace FastFood.WebApi.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService service;

        public OrdersController(IOrderService service)
        {
            this.service = service;
        }
        public async ValueTask<IActionResult> PostAsync(OrderForCreationDto dto)
        {
            return Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.AddAsync(dto)
            });
        }
        [HttpDelete("id")]
        public async ValueTask<IActionResult> DeleteAsync(long id) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await service.RemoveAsync(id)
            });
        [HttpGet("id")]
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
