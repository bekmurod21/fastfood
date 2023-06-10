using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Users;
using FastFood.Service.DTOs.UserDto;
using System.Linq.Expressions;

namespace FastFood.Service.Interfaces;

public interface IUserService
{
    ValueTask<UserForResultDto> AddAsync(UserForCreationDto model);
    ValueTask<UserForResultDto> ModifyAsync(long id,UserForUpdateDto model);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<UserForResultDto> RetrieveAsync(long id);
    ValueTask<IEnumerable<UserForResultDto>> RetrieveAll(PaginationParams @params);
}
