using AutoMapper;
using FastFood.Data.Contexts;
using FastFood.Domain.Helpers;
using FastFood.Data.IRepositories;
using FastFood.Service.Extensions;
using FastFood.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using FastFood.Service.DTOs.RoleDto;
using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Users;
using FastFood.Domain.Entities.Authorizations;
using FastFood.Service.Interfaces.Authorizations;

namespace FastFood.Service.Services.Authorizations
{
    public class RoleService : IRoleService
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Role> roleRepository;
        private readonly AppDbContext dbContext;
        public RoleService(IMapper mapper, IRepository<Role> roleRepository, IRepository<User> userRepository, AppDbContext dbContext)
        {
            this.mapper = mapper;
            this.roleRepository = roleRepository;
            this.userRepository = userRepository;
            this.dbContext = dbContext;
        }

        public async Task<RoleForResultDto> AddAsync(RoleForCreationDto dto)
        {
            var exist = await this.roleRepository.SelectAsync(r => r.Name.Equals(dto.Name) && r.IsDeleted == true);
            if (exist is not null)
                throw new CustomException(404, "Role is already exist");

            var mappedDto = mapper.Map<Role>(dto);
            await this.roleRepository.InsertAsync(mappedDto);

            return mapper.Map<RoleForResultDto>(mappedDto);
        }

        public async Task<bool> AssignRoleForUserAsync(long userId, long roleId)
        {
            var user = await this.userRepository.SelectAsync(u=>u.Id==userId);
            var role = await this.roleRepository.SelectAsync(r => r.Id == roleId);
            if (role is null || user is null)
                throw new CustomException(404, "User or Role not found");
            user.RoleId = roleId;
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ModifyAsync(RoleForUpdateDto dto)
        {
            var role = await this.roleRepository.SelectAsync(r=>r.Id == dto.Id && r.IsDeleted == false);
            if (role is null)
                throw new CustomException(404, "Role is not found");

            var mapped = mapper.Map(dto,role);
            mapped.UpdatedAt = DateTime.Now;
            mapped.UpdatedBy = HttpContextHelper.UserId;
            await this.roleRepository.UpdateAsync(mapped);
            return true;
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var exist = await this.roleRepository.SelectAsync(r=>r.Id == id && r.IsDeleted ==false);
            if (exist is null)
                throw new CustomException(404, "Role is not found");

            exist.DeletedAt = DateTime.Now;
            exist.DeletedBy = HttpContextHelper.UserId;

            return await this.roleRepository.DeleteAsync(r=>r.Id==exist.Id);
        }

        public async Task<IEnumerable<RoleForResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            var roles = await this.roleRepository.SelectAllAsync()
                .Where(r => r.IsDeleted == false)
                .ToPagedList(@params)
                .ToListAsync();
            return this.mapper.Map<IEnumerable<RoleForResultDto>>(roles);
        }

        public async Task<RoleForResultDto> RetrieveByIdAsync(long id)
        {
            var exist = await this.roleRepository.SelectAsync(r=>r.Id==id && r.IsDeleted == false);
            if (exist is null)
                throw new CustomException(404, "Role is not found");
             
            return this.mapper.Map<RoleForResultDto>(exist);
        }

        public async Task<Role> RetrieveByIdForAuthAsync(long id)
        {
            var exist = await this.roleRepository.SelectAsync(r=>r.Id==id && r.IsDeleted == false);
            if (exist is null)
                throw new CustomException(404, "Role is not found");

            return exist;
        }
    }
}
