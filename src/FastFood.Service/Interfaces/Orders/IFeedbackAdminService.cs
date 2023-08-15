using FastFood.Domain.Configurations;
using FastFood.Domain.Enums;
using FastFood.Service.DTOs.Feedbacks;

namespace FastFood.Service.Interfaces.Orders
{
    public interface IFeedbackAdminService
    {
        Task<IEnumerable<FeedbackForResultDto>> RetrieveAllByClientIdAsync(long clientId);
        Task<IEnumerable<FeedbackForResultDto>> RetriveAllByStatusAsync(PaginationParams @params,
        FeedbackStatus? status = null);
        Task<bool> MarkAsReadAsync(long id);
    }
}
