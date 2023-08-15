using FastFood.Data.Contexts;
using FastFood.Data.IRepositories;
using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Orders.Feedbacks;
using FastFood.Domain.Enums;
using FastFood.Service.DTOs.Feedbacks;
using FastFood.Service.Exceptions;
using FastFood.Service.Extensions;
using FastFood.Service.Interfaces.Orders;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Service.Services.Feedbacks
{
    public class FeedbackAdminService : IFeedbackAdminService
    {
        private readonly IRepository<Feedback> repository;
        private readonly AppDbContext dbContext;
        public FeedbackAdminService(IRepository<Feedback> repository, AppDbContext dbContext)
        {
            this.repository = repository;
            this.dbContext = dbContext;
        }

        public async Task<bool> MarkAsReadAsync(long id)
        {
            var feedback = await this.repository.SelectAsync(f => f.Id == id && !f.IsDeleted);
            if (feedback is null)
                throw new CustomException(404, "Feedback is not found");

            feedback.FeedbackStatus = FeedbackStatus.Seen;
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FeedbackForResultDto>> RetrieveAllByClientIdAsync(long clientId)
        {

            var feedbacks = await this.repository
                .SelectAllAsync(f => !f.IsDeleted && f.Order.User.Id == clientId, new string[] { "Attachments.Attachment" })
                .ToArrayAsync();
            if (feedbacks is null || !feedbacks.Any())
                throw new CustomException(404, "Feedback not found");

            return Array.ConvertAll<Feedback, FeedbackForResultDto>(feedbacks, x => x.ToFeedbackResultDto());
        }

        public async Task<IEnumerable<FeedbackForResultDto>> RetriveAllByStatusAsync(PaginationParams @params, FeedbackStatus? status = null)
        {
            var feedbacksQuery = this.repository.SelectAllAsync(f => !f.IsDeleted, new string[] { "Attachments.Attachment" });
            if (status is not null)
                feedbacksQuery = feedbacksQuery.Where(f => f.FeedbackStatus == status);

            feedbacksQuery = feedbacksQuery.ToPagedList(@params);

            var feedbacks = await feedbacksQuery.ToArrayAsync();
            if (feedbacks is null || !feedbacks.Any())
                throw new CustomException(404, "Feedback not found");

            return Array.ConvertAll<Feedback, FeedbackForResultDto>(feedbacks, x => x.ToFeedbackResultDto());
        }
    }
}
