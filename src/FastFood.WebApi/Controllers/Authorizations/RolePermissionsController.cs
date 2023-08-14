using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.RolePermissionDto;
using FastFood.Service.Interfaces.Authorizations;
using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.WebApi.Controllers.Authorizations
{
    public class RolePermissionsController : RestfulSense
    {
        private readonly IRolePermissionService rolePermissionService;

        public RolePermissionsController(IRolePermissionService rolePermissionService)
        {
            this.rolePermissionService = rolePermissionService;
        }
        

        [HttpPost]
        public async Task<IActionResult> PostAsync(RolePermissionForCreationDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await this.rolePermissionService.CreateAsync(dto)
            });

        [HttpPut]
        public async Task<IActionResult> PutAsync(RolePermissionForUpdateDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await this.rolePermissionService.ModifyAsync(dto)
            });
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await this.rolePermissionService.RemoveAsync(id)
            });

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await this.rolePermissionService.RetrieveByIdAsync(id)
            });

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
           => Ok(new Response
           {
               Code = 200,
               Message = "OK",
               Data = await this.rolePermissionService.RetrieveAllAsync(@params)
           });

    }
}
