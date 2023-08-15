using AutoMapper;
using FastFood.Service.Exceptions;
using FastFood.Service.Extensions;
using FastFood.Data.IRepositories;
using FastFood.Service.DTOs.Feedbacks;
using FastFood.Domain.Entities.Orders;
using FastFood.Service.DTOs.Attachment;
using FastFood.Service.Interfaces.Orders;
using FastFood.Service.Interfaces.Attachments;
using FastFood.Domain.Entities.Orders.Feedbacks;

namespace FastFood.Service.Services.Feedbacks
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Feedback> repository;
        private readonly IRepository<Order> orderRepository;
        private readonly IAttachmentService attachmentService;
        private readonly IRepository<FeedbackAttachment> feedbackAttachment;
        public FeedbackService(IMapper mapper,
            IRepository<Feedback> repository,
            IRepository<Order> orderRepository,
            IAttachmentService attachmentService,
            IRepository<FeedbackAttachment> feedbackAttachment)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.orderRepository = orderRepository;
            this.attachmentService = attachmentService;
            this.feedbackAttachment = feedbackAttachment;
        }

        public async Task<FeedbackForResultDto> AddAsync(FeedbackForCreationDto dto, List<AttachmentForCreationDto> attachments)
        {
            var order = await this.orderRepository.SelectAsync(o => o.Id == dto.OrderId && !o.IsDeleted);
            if (order is null)
                throw new CustomException(404, "Order is not found");

            var feedback = this.mapper.Map<Feedback>(dto);
            var insertedFeedback = await this.repository.InsertAsync(feedback);

            var result =  mapper.Map<FeedbackForResultDto>(insertedFeedback);

            if (attachments is not null && attachments.Any())
            {
                foreach(var attachment in attachments)
                {
                    var insertedAttachment = await this.attachmentService.UploadAsync(attachment);
                    result.Attachments.Add(this.mapper.Map<AttachmentForResultDto>(insertedAttachment));

                    await this.feedbackAttachment.InsertAsync(new FeedbackAttachment
                    {
                        AttachmentId = insertedAttachment.Id,
                        FeedbackId = insertedFeedback.Id
                    });
                }
            }
            return result;
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var feedback = await this.repository.SelectAsync(f => f.Id == id && !f.IsDeleted, new string[] { "Attachments.Attachment" });
            if (feedback is null)
                throw new CustomException(404, "Feedback not found");

            
            foreach (var attachment in feedback.FeedbackAttachments)
            {
                await attachmentService.RemoveAsync(attachment.Attachment.Id);
                await feedbackAttachment.DeleteAsync(fa => fa.Id == attachment.Id);
            }

            var isDeleted = await repository.DeleteAsync(f => f.Id == id);

            return isDeleted;
        }

        public async Task<FeedbackForResultDto> RetrieveAsync(long id)
        {
            Feedback feedback = await this.repository.SelectAsync(f => !f.IsDeleted && f.Id == id, new string[] { "Attachments.Attachment" });
            if (feedback is null)
                throw new CustomException(404, "Feedback not found");

            return feedback.ToFeedbackResultDto();
        }
    }
}
