using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Users;
using FastFood.Service.DTOs.UserDto;
using FastFood.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> InsertAsync([FromBody] UserForCreationDto userDto) =>
            Ok(await this.userService.AddAsync(userDto));

        /// <summary>
        /// Get all user
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Policy = "AdminPolicy")]
        public IActionResult SelectAllAsync([FromQuery] PaginationParams @params) =>
            Ok(this.userService.SelectAll(@params));

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async ValueTask<IActionResult> SelectByIdAsync(long id) =>
            Ok(await this.userService.SelectAsync(id));

        /// <summary>
        /// Update by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateByIdAsync(long id,[FromBody] UserForCreationDto user)=>
            Ok(await this.userService.ModifyAsync(id,user));

        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteByIdAsync(long id) =>
            Ok(await this.userService.DeleteAsync(id));
    }
}
