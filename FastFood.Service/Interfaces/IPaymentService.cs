using FastFood.Domain.Entities.Orders;
using FastFood.Service.DTOs.OrderDto;

namespace FastFood.Service.Interfaces;

public interface IPaymentService
{
    ValueTask<Payment> AddAsync(PaymentForCreationDto model);
    ValueTask<Payment> ModifyAsync(long id, PaymentForCreationDto model);
    ValueTask<Payment> DeleteAsync(long id);
    ValueTask<Payment> SelectAsync(long id);
    IEnumerable<Payment> SelectAllAsync();
}
