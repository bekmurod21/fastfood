using FastFood.Service.DTOs.UserDto;
using FastFood.Domain.Configurations;

namespace FastFood.Service.Interfaces;

public interface IUserService
{
    ValueTask<UserForResultDto> AddAsync(UserForCreationDto model);
    ValueTask<UserForResultDto> ModifyAsync(long id,UserForUpdateDto model);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<UserForResultDto> RetrieveAsync(long id);
    ValueTask<IEnumerable<UserForResultDto>> RetrieveAll(PaginationParams @params);
}
