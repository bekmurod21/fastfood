using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.PermissionDto;
using FastFood.Service.Interfaces.Authorizations;
using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.WebApi.Controllers.Authorizations
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            this.permissionService = permissionService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PermissionForCreationDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await this.permissionService.CreateAsync(dto)
            });

        [HttpPut]
        public async Task<IActionResult> PutAsync(PermissionForUpdateDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await this.permissionService.ModifyAsync(dto)
            });


        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await this.permissionService.RemoveAsync(id)
            });

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
          => Ok(new Response
          {
              Code = 200,
              Message = "OK",
              Data = await this.permissionService.RetrieveByIdAsync(id)
          });

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
          => Ok(new Response
          {
              Code = 200,
              Message = "OK",
              Data = await this.permissionService.RetrieveAllAsync(@params)
          });
    }
}
