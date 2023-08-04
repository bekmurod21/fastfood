using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using FastFood.Service.Interfaces;
using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.AddressDto;

namespace FastFood.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService service;

        public AddressesController(IAddressService service)
        {
            this.service = service;
        }
        public async ValueTask<IActionResult> PostAsync(AddressForCreationDto dto)
        {
            return Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.service.AddAsync(dto)
            });
        }
        [HttpPut("id")]
        public async ValueTask<IActionResult> PutAsync(long id, AddressForCreationDto dto)
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
