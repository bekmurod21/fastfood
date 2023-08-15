using FastFood.Service.DTOs.Attachment;
using FastFood.Service.DTOs.Feedbacks;

namespace FastFood.Service.Interfaces.Orders
{
    public interface IFeedbackService
    {
        Task<FeedbackForResultDto> AddAsync(FeedbackForCreationDto dto, List<AttachmentForCreationDto> attachments);
        Task<bool> RemoveAsync(long id);
        Task<FeedbackForResultDto> RetrieveAsync(long id);

    }
}
