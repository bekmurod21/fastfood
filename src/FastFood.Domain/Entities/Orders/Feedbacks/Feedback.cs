using FastFood.Domain.Commons;
using FastFood.Domain.Enums;

namespace FastFood.Domain.Entities.Orders.Feedbacks
{
    public class Feedback:Auditable
    {
        public string Message { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }

        public FeedbackStatus FeedbackStatus = FeedbackStatus.NotSeen;

        public ICollection<FeedbackAttachment> FeedbackAttachments { get; set; }

    }
}
