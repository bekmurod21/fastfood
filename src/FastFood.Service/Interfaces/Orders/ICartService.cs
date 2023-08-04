using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.CartDto;

namespace FastFood.Service.Interfaces.Order
{
    public interface ICartService
    {
        ValueTask<CartItemForResultDto> AddAsync(CartItemForCreationDto dto);
        ValueTask<CartItemForResultDto> ModifyAsync(CartItemForUpdateDto dto);
        ValueTask<bool> RemoveAsync(long id);
        ValueTask<CartItemForResultDto> RetrieveByIdAsync(long id);
        ValueTask<IEnumerable<CartItemForResultDto>> RetrieveAllAsync(PaginationParams @params);
        ValueTask<CartForResultDto> RetrieveByClientIdAsync();
    }
}
