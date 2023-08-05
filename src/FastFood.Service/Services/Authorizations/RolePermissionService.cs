using AutoMapper;
using FastFood.Data.IRepositories;
using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Authorizations;
using FastFood.Service.DTOs.RolePermissionDto;
using FastFood.Service.Exceptions;
using FastFood.Service.Extensions;
using FastFood.Service.Interfaces.Authorizations;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Service.Services.Authorizations
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IMapper mapper;
        private readonly IRepository<RolePermission> repository;
        public RolePermissionService(IMapper mapper, IRepository<RolePermission> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<bool> CheckPermission(string role, string accessedMethod)
        {

            var permissions = await this.repository
                .SelectAllAsync(p => p.Roles.Name.ToLower() == role.ToLower() && p.Permissions.IsDeleted == false && p.Roles.IsDeleted == false, new string[] { "Permisson" })
                .ToListAsync();
            foreach (var permission in permissions)
            {
                if (permission?.Permissions?.Name.ToLower() == accessedMethod.ToLower())
                    return true;
            }

            return false;
        }

        public async Task<RolePermissionForResultDto> CreateAsync(RolePermissionForCreationDto permission)
        {
            var rolePermission = await this.repository.SelectAsync(rp => rp.RoleId == permission.RoleId && rp.PermissionId == permission.PermissonId && rp.IsDeleted == true);
            if (rolePermission is not null)
                throw new CustomException(409, "RolePermission is already exist");
            var mappedPermission = this.mapper.Map<RolePermission>(rolePermission);
            mappedPermission.CreatedAt = DateTime.UtcNow;
            return mapper.Map<RolePermissionForResultDto>(await this.repository.InsertAsync(mappedPermission));
        }

        public async Task<RolePermissionForResultDto> ModifyAsync(RolePermissionForUpdateDto permission)
        {
            var rolePermission = await this.repository.SelectAsync(rp=>rp.Id == permission.Id && rp.IsDeleted == false);
            if (rolePermission is null)
                throw new CustomException(404, "RolePermission is not available");
            var result = this.mapper.Map(permission, rolePermission);
            result.UpdatedAt = DateTime.UtcNow;

            return this.mapper.Map<RolePermissionForResultDto>(await this.repository.UpdateAsync(result));
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var rolePermission = await this.repository.SelectAsync(rp=>rp.Id == id && rp.IsDeleted == false);
            if (rolePermission is null)
                throw new CustomException(404, "RolePermission is not available");
            rolePermission.DeletedAt = DateTime.UtcNow;
            
            return await this.repository.DeleteAsync(rp=>rp.Id == rolePermission.Id);
        }

        public async Task<List<RolePermissionForResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            var rolePermissions = await this.repository.SelectAllAsync()
                .Where(rp => rp.IsDeleted == false)
                .ToPagedList(@params)
                .ToListAsync();

            return this.mapper.Map<List<RolePermissionForResultDto>>(rolePermissions);
        }

        public async Task<RolePermissionForResultDto> RetrieveByIdAsync(long id)
        {
            var rolePermission = await this.repository.SelectAllAsync(rp => rp.Id == id && rp.IsDeleted == false && rp.Permissions.IsDeleted == false && rp.Roles.IsDeleted == false, new string[] { "Permisson", "Role" })
                .FirstOrDefaultAsync();
            if (rolePermission is null)
                throw new CustomException(404, "RolePermission is not found");

            return this.mapper.Map<RolePermissionForResultDto>(rolePermission);

        }
    }
}
