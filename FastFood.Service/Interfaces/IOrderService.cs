using FastFood.Domain.Entities.Orders;
using FastFood.Service.DTOs.OrderDto;

namespace FastFood.Service.Interfaces;

public interface IOrderService
{
    ValueTask<Order> AddAsync(OrderForCreationDto model);
    ValueTask<Order> ModifyAsync(long id,OrderForCreationDto model);
    ValueTask<Order> DeleteAsync(long id);
    ValueTask<Order> SelectAsync(long id);
    IEnumerable<Order> SelectAll();

}
