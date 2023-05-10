using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Users;
using FastFood.Service.DTOs.UserDto;
using System.Linq.Expressions;

namespace FastFood.Service.Interfaces;

public interface IUserService
{
    ValueTask<User> AddAsync(UserForCreationDto model);
    ValueTask<User> ModifyAsync(long id, UserForCreationDto model);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<User> SelectAsync(long id);
    ValueTask<IEnumerable<User>> SelectAll(PaginationParams @params);
}
