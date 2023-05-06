using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.UserDto;
using FastFood.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> InsertAsync([FromBody] UserForCreationDto userDto)=>
            Ok(await this.userService.AddAsync(userDto));

        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult SelectAllAsync([FromQuery] PaginationParams @params) =>
            Ok(this.userService.SelectAll(@params));  
    }
}
