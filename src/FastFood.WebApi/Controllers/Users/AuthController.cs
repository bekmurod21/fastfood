using FastFood.Service.DTOs.LoginDto;
using FastFood.Service.Interfaces.Users;
using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.WebApi.Controllers.Users
{
    public class AuthController : RestfulSense
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        /// <summary>
        /// login is email,username or phone
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(LoginForCreationDto dto)
        {
            return Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await authService.AuthenticateAsync(dto)
            });
        }
    }
}
