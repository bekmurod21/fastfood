using AutoMapper;
using FastFood.Domain.Enums;
using FastFood.Data.IRepositories;
using FastFood.Service.Interfaces;
using FastFood.Service.DTOs.Commons;
using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Orders;
using FastFood.Service.DTOs.PaymentDto;
using FastFood.Service.Helpers;
using FastFood.Domain.Entities.Payment;

namespace FastFood.Service.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly IRepository<Order> orderRepository;
        private readonly IAttachmentService attachmentService;
        private readonly IRepository<Payment> paymentRepository;
        public PaymentService(IRepository<Payment> repository, IMapper mapper, IUserService userService,
            IRepository<Order> orderRepository, IAttachmentService attachmentService)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.paymentRepository = repository;
            this.orderRepository = orderRepository;
            this.attachmentService = attachmentService;
        }

        public async ValueTask<PaymentForResultDto> AddAsync(PaymentForCreationDto model, AttachmentForCreationDto attachment)
        {
            var user = userService.RetrieveAsync(model.UserId);
            var order = orderRepository.SelectAsync(o => o.Id == model.OrderId);
            var file = await attachmentService.UploadAsync(attachment);

            Payment payment = new Payment()
            {
                Amount = model.Amount,
                IsAdmin = model.IsAdmin,
                Status = PaymentStatus.Pending,
                Description = model.Description,
                Attachment = new Domain.Entities.Commons.Attachment()
                {
                    FileName = attachment.FileName,
                    FilePath = attachment.FilePath
                }
            };
            payment.UserId = (long)HttpContextHelper.UserId;
            payment.Order = order;
        }

        public ValueTask<PaymentForResultDto> ChangeStatusAsync(long id, PaymentStatus status)
        {
            throw new NotImplementedException();
        }

        public ValueTask<PaymentForResultDto> ModifyAsync(long id, PaymentForCreationDto model)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentForResultDto> RetrieveAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public ValueTask<PaymentForResultDto> RetrieveAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
