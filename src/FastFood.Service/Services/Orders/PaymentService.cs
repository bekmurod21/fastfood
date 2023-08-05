using AutoMapper;
using FastFood.Domain.Enums;
using FastFood.Service.Helpers;
using FastFood.Data.IRepositories;
using FastFood.Service.Exceptions;
using FastFood.Service.Extensions;
using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Entities.Payment;
using FastFood.Service.DTOs.Attachment;
using FastFood.Service.DTOs.PaymentDto;
using FastFood.Service.Interfaces.Orders;
using FastFood.Service.Interfaces.Attachments;
using Microsoft.EntityFrameworkCore;
using FastFood.Service.Interfaces.Users;

namespace FastFood.Service.Services.Orders
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Payment> paymentRepository;
        private readonly IAttachmentService attachmentService;

        public PaymentService(IMapper mapper, IUserService userService,
            IRepository<Order> orderRepository,
            IRepository<Payment> paymentRepository,
            IAttachmentService attachmentService)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.orderRepository = orderRepository;
            this.paymentRepository = paymentRepository;
            this.attachmentService = attachmentService;
        }


        public async ValueTask<PaymentForResultDto> AddAsync(PaymentForCreationDto model,
            AttachmentForCreationDto attachment)
        {
            var user = await userService.RetrieveAsync(model.UserId);
            var order = await orderRepository.SelectAsync(order => order.Id == model.OrderId);
            var file = await this.attachmentService.UploadAsync(attachment);

            Payment payment = new Payment
            {
                Amount = model.Amount,
                Description = model.Description,
                IsAdmin = model.IsAdmin,
                Status = PaymentStatus.Pending,
                Attachment = new()
                {
                    FileName = file.FileName,
                    FilePath = file.FilePath
                }
            };
            payment.UserId = (long)HttpContextHelper.UserId;
            payment.Order = order;

            var inserted = await paymentRepository.InsertAsync(payment);
            return mapper.Map<PaymentForResultDto>(inserted);
        }

        public async ValueTask<PaymentForResultDto> ChangeStatusAsync(long id, PaymentStatus status)
        {
            Payment payment = await paymentRepository.SelectAsync(t => t.Id == id);
            if (payment is null)
                throw new CustomException(404, "Payment is not found");

            payment.Status = status;
            payment = await paymentRepository.UpdateAsync(payment);

            return mapper.Map<PaymentForResultDto>(payment);
        }

        public async ValueTask<PaymentForResultDto> ModifyAsync(long id, PaymentForCreationDto model)
        {
            Payment payment = await paymentRepository.SelectAsync(t => t.Id == id);
            if (payment is null)
                throw new CustomException(404, "Payment is not found");

            Payment mappedPayment = mapper.Map<Payment>(model);
            mappedPayment.Id = id;
            mappedPayment.UpdatedAt = DateTime.UtcNow;
            mappedPayment.CreatedAt = payment.CreatedAt;
            payment = await paymentRepository.UpdateAsync(payment);

            return mapper.Map<PaymentForResultDto>(payment);
        }

        public async ValueTask<bool> RemoveAsync(long id)
        {
            Payment payment = await paymentRepository.SelectAsync(t => t.Id == id);
            if (payment is null)
                throw new CustomException(404, "Payment is not found");

            await paymentRepository.DeleteAsync(t => t.Id == id);
            return true;
        }

        public async Task<IEnumerable<PaymentForResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            var payments = await paymentRepository.SelectAllAsync()
                .ToPagedList(@params)
                .ToListAsync();
            return mapper.Map<IEnumerable<PaymentForResultDto>>(payments);
        }

        public async ValueTask<PaymentForResultDto> RetrieveAsync(long id)
        {
            Payment payment = await paymentRepository.SelectAsync(t => t.Id == id);
            if (payment is null)
                throw new CustomException(404, "Payment is not found");
            return mapper.Map<PaymentForResultDto>(payment);
        }
    }
}
