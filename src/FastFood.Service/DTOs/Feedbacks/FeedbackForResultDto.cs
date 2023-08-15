using FastFood.Domain.Enums;
using FastFood.Service.DTOs.Attachment;

namespace FastFood.Service.DTOs.Feedbacks
{
    public class FeedbackForResultDto
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string Message { get; set; }
        public FeedbackStatus Status { get; set; }

        public List<AttachmentForResultDto> Attachments { get; set; }
    }
}
