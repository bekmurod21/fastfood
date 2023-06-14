using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Enums;
using FastFood.Service.DTOs.Commons;
using FastFood.Service.DTOs.PaymentDto;

namespace FastFood.Service.Interfaces;

public interface IPaymentService
{
    ValueTask<PaymentForResultDto> AddAsync(PaymentForCreationDto model,AttachmentForCreationDto attachment);
    ValueTask<PaymentForResultDto> ModifyAsync(long id, PaymentForCreationDto model);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<PaymentForResultDto> RetrieveAsync(long id);
    IEnumerable<PaymentForResultDto> RetrieveAllAsync(PaginationParams @params);
    ValueTask<PaymentForResultDto> ChangeStatusAsync(long id,PaymentStatus status);
}
