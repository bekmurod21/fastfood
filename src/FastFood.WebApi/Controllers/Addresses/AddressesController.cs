using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.AddressDto;
using FastFood.Service.Interfaces.Addresses;

namespace FastFood.WebApi.Controllers.Addresses
{
    public class AddressesController : RestfulSense
    {
        private readonly IAddressService service;

        public AddressesController(IAddressService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async ValueTask<IActionResult> PostAsync(AddressForCreationDto dto)
        {
            return Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await service.AddAsync(dto)
            });
        }
        [HttpPut]
        public async ValueTask<IActionResult> PutAsync(long id, AddressForCreationDto dto)
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
