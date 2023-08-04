using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.PermissionDto;

namespace FastFood.Service.Interfaces.Authorizations
{
    public interface IPermissionService
    {
        Task<bool> RemoveAsync(long id);
        Task<PermissionForResultDto> RetrieveByIdAsync(long id);
        Task<PermissionForResultDto> ModifyAsync(PermissionForUpdateDto dto);
        Task<PermissionForResultDto> CreateAsync(PermissionForCreationDto dto);
        Task<List<PermissionForResultDto>> RetrieveAllAsync(PaginationParams @params);
    }
}
