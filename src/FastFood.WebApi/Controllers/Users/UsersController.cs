using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using FastFood.Service.DTOs.UserDto;
using FastFood.Domain.Configurations;
using FastFood.Service.Interfaces.Users;

namespace FastFood.WebApi.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostAsyn(UserForCreationDto dto) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Seccess",
                Data = await service.AddAsync(dto)
            });
        [HttpPut("id")]
        public async ValueTask<IActionResult> PutAsync(long id, UserForUpdateDto dto) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await service.ModifyAsync(id, dto)
            });
        [HttpDelete("id")]
        public async ValueTask<IActionResult> DeleteAsync(long id) =>
            Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await service.RemoveAsync(id)
            });
        [HttpGet("id")]
        public async ValueTask<IActionResult> GetById(long id) =>
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
                Data = await service.RetrieveAll(@params)
            });
    }
}
