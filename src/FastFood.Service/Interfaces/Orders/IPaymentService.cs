using FastFood.Domain.Enums;
using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.PaymentDto;
using FastFood.Service.DTOs.Attachment;

namespace FastFood.Service.Interfaces.Orders;

public interface IPaymentService
{
    ValueTask<PaymentForResultDto> AddAsync(PaymentForCreationDto model, AttachmentForCreationDto attachment);
    ValueTask<PaymentForResultDto> ModifyAsync(long id, PaymentForCreationDto model);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<PaymentForResultDto> RetrieveAsync(long id);
    Task<IEnumerable<PaymentForResultDto>> RetrieveAllAsync(PaginationParams @params);
    ValueTask<PaymentForResultDto> ChangeStatusAsync(long id, PaymentStatus status);
}
