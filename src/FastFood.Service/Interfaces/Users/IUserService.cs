using FastFood.Service.DTOs.UserDto;
using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Users;

namespace FastFood.Service.Interfaces.Users;

public interface IUserService
{
    ValueTask<UserForResultDto> AddAsync(UserForCreationDto model);
    ValueTask<UserForResultDto> ModifyAsync(long id, UserForUpdateDto model);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<UserForResultDto> RetrieveAsync(long id);
    ValueTask<IEnumerable<UserForResultDto>> RetrieveAll(PaginationParams @params);
    ValueTask<User> RetrieveByEmailAsync(string email);
    Task<UserForResultDto> ChangePasswordAsync(UserForChangePasswordDto dto);
    ValueTask<User> RetrieveByLoginAsync(string login);
}
