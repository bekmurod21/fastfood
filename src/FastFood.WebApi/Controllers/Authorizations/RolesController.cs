using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.RoleDto;
using FastFood.Service.Interfaces.Authorizations;
using FastFood.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.WebApi.Controllers.Authorizations;

    public class RolesController : RestfulSense
    {
        private readonly IRoleService roleService;

        public RolesController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(RoleForCreationDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await this.roleService.AddAsync(dto)
            });

        [HttpPut]
        public async Task<IActionResult> PutAsync(RoleForUpdateDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await this.roleService.ModifyAsync(dto)
            });

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await this.roleService.RemoveAsync(id)
            });

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
            => Ok(new Response
            {
                Code = 200,
                Message = "OK",
                Data = await this.roleService.RetrieveByIdAsync(id)
            });

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
          => Ok(new Response
          {
              Code = 200,
              Message = "OK",
              Data = await this.roleService.RetrieveAllAsync(@params)
          });
        [HttpPut("assign-role")]
        public async Task<IActionResult> AssignRoleForUser(long userId, long roleId)
            => Ok(new Response
            {
                Code = 200,
                Message = "Ok",
                Data = await this.roleService.AssignRoleForUserAsync(userId, roleId)
            });
    }

