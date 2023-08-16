using AutoMapper;
using FastFood.Domain.Helpers;
using FastFood.Data.IRepositories;
using FastFood.Service.Exceptions;
using FastFood.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.PermissionDto;
using FastFood.Domain.Entities.Authorizations;
using FastFood.Service.Interfaces.Authorizations;

namespace FastFood.Service.Services.Authorizations
{
    public class PermissionService : IPermissionService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Permission> repository;

        public PermissionService(IMapper mapper,IRepository<Permission> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<PermissionForResultDto> CreateAsync(PermissionForCreationDto dto)
        {
            var permission = await this.repository.SelectAsync(p => p.Name.ToLower() == dto.Name.ToLower() && p.IsDeleted == true);
            if (permission is not null)
                throw new CustomException(409, "Permission is already available");

            var mappedPermission = this.mapper.Map<Permission>(dto);
            mappedPermission.CreatedAt = DateTime.UtcNow;
            var result = await this.repository.InsertAsync(mappedPermission);

            return this.mapper.Map<PermissionForResultDto>(result);
        }

        public async Task<PermissionForResultDto> ModifyAsync(PermissionForUpdateDto dto)
        {
            var permission = await this.repository.SelectAsync(p => p.Id == dto.Id && p.IsDeleted == false);
            if (permission is null)
                throw new CustomException(404, "Permission is not found ");

            var result = this.mapper.Map(dto, permission);
            result.UpdatedAt = DateTime.UtcNow;
            
            return this.mapper.Map<PermissionForResultDto>(await this.repository.UpdateAsync(result));
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var permission = await this.repository.SelectAsync(p => p.Id == id && !p.IsDeleted);
            if (permission is null)
                throw new CustomException(404, "Permission is not available");
            permission.DeletedAt = DateTime.UtcNow;
            permission.DeletedBy = HttpContextHelper.UserId;

            return await this.repository.DeleteAsync(p => p.Id == permission.Id);
        }

        public async Task<List<PermissionForResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            var permissions = await this.repository.SelectAllAsync()
                .Where(p => p.IsDeleted == false)
                .ToPagedList(@params)
                .ToListAsync();

            return  this.mapper.Map<List<PermissionForResultDto>>(permissions);
        }

        public async Task<PermissionForResultDto> RetrieveByIdAsync(long id)
        {
            var permission = await this.repository.SelectAsync(p => p.Id == id && !p.IsDeleted);
            if (permission is null)
                throw new CustomException(404, "Permission is not available");

            return mapper.Map<PermissionForResultDto>(permission);
        }
    }
}
