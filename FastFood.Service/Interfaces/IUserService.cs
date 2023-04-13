using FastFood.Domain.Entities;
using FastFood.Service.DTOs.UserDto;
using FastFood.Service.Helpers;
using System.Linq.Expressions;

namespace FastFood.Service.Interfaces
{
    public interface IUserService
    {
        ValueTask<UserForResultDto> AddAsync(UserForCreationDto dto);
        ValueTask<UserForResultDto> ModifyAsync(long id, UserForResultDto dto);
        ValueTask<UserForResultDto> SelectAsync(Expression<Func<User, bool>> expression);
        ValueTask<IEnumerable<UserForResultDto>> SelectAllAsync(Expression<Func<User, bool>> expression = null, string search = null);
        ValueTask<bool> DeleteAsync(Expression<Func<User, bool>> expression);
        ValueTask<UserForResultDto> ChangePasswordAsync(UserForChangePassword dto);
    }
}
