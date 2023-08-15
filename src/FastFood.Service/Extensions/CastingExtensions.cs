using FastFood.Domain.Entities.Orders.Feedbacks;
using FastFood.Service.DTOs.Attachment;
using FastFood.Service.DTOs.Feedbacks;
using System.Runtime.CompilerServices;

namespace FastFood.Service.Extensions
{
    public static class CastingExtensions
    {
        public static FeedbackForResultDto ToFeedbackResultDto(this Feedback feedback)
        {
            var result = new FeedbackForResultDto();
            result.Id = feedback.Id;
            result.Message = feedback.Message;
            result.Status = feedback.FeedbackStatus;
            result.OrderId = feedback.OrderId;
            if(feedback.FeedbackAttachments is not null && feedback.FeedbackAttachments.Any())
            {
                result.Attachments = new List<AttachmentForResultDto>();
                foreach(var attachment in feedback.FeedbackAttachments)
                {
                    var attachmentDto = new AttachmentForResultDto
                    {
                        Id = attachment.Attachment.Id,
                        FileName = attachment.Attachment.FileName,
                    };
                    result.Attachments.Add(attachmentDto);
                }

            }
            return result;
        }
    }
}
