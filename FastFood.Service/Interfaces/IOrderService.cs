using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Enums;
using FastFood.Service.DTOs.OrderDto;

namespace FastFood.Service.Interfaces;

public interface IOrderService
{
    ValueTask<OrderForResultDto> AddAsync(OrderForCreationDto orderForCreationDto);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<OrderForResultDto> RetrieveAsync(long id);
    ValueTask<IEnumerable<OrderForResultDto>> RetrieveAllByClientIdAsync(long clientId);
    ValueTask<IEnumerable<OrderForResultDto>> RetrieveAllAsync(
        PaginationParams @params, OrderStatus? status = null);
    ValueTask<IEnumerable<OrderForResultDto>> RetrieveAllByPhoneAsync(
        PaginationParams @params, string phone, OrderStatus? status = null);

}
