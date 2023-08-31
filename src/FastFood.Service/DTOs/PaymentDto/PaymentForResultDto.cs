using FastFood.Domain.Enums;
using FastFood.Service.DTOs.OrderDto;
using FastFood.Service.DTOs.UserDto;

namespace FastFood.Service.DTOs.PaymentDto
{
    public class PaymentForResultDto
    {
        public long Id { get; set; }
        public decimal? Amount { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public PaymentStatus Status { get; set; }
        public bool IsAdmin { get; set; }

        public UserForResultDto User { get; set; }
        public OrderForResultDto Order { get; set; }
    }
}
