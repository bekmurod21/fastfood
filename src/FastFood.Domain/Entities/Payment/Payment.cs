using FastFood.Domain.Enums;
using FastFood.Domain.Commons;
using FastFood.Domain.Entities.Users;
using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Entities.Attachments;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFood.Domain.Entities.Payments
{
    public class Payment : Auditable
    {
        public decimal? Amount { get; set; }
        public string Description { get; set; }
        public PaymentStatus Status { get; set; }
        public bool IsAdmin { get; set; }

        [ForeignKey("user_id")]
        public long UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("order_id")]
        public long OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey("attachment_id")]
        public long AttachmentId { get; set; }
        public Attachment Attachment { get; set; }

    }
}
