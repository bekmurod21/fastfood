using FastFood.Service.DTOs.OrderDto;

namespace FastFood.Service.Interfaces.Orders;

public interface IOrderActionService
{
    ValueTask<OrderForResultDto> StartPendingAsync(long orderId);
    ValueTask<OrderForResultDto> StartPreparingAsync(long orderId);
    ValueTask<OrderForResultDto> StartShippingAsync(long orderId);
    ValueTask<OrderForResultDto> FinishDeliveryAsync(long orderId);
    ValueTask<OrderForResultDto> CancelledAsync(long orderId);
}
