using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Authorizations;
using FastFood.Service.DTOs.RoleDto;

namespace FastFood.Service.Interfaces.Authorizations
{
    public interface IRoleService
    {
        Task<bool> RemoveAsync(long id);
        Task<bool> ModifyAsync(RoleForUpdateDto dto);
        Task<Role> RetrieveByIdForAuthAsync(long id);
        Task<RoleForResultDto> RetrieveByIdAsync(long id);
        Task<RoleForResultDto> AddAsync(RoleForCreationDto dto);
        Task<bool> AssignRoleForUserAsync(long userId, long roleId);
        Task<IEnumerable<RoleForResultDto>> RetrieveAllAsync(PaginationParams @params);
    }
}
