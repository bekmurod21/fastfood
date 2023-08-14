using FastFood.Data.IRepositories;
using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Enums;
using FastFood.Service.DTOs.OrderDto;
using FastFood.Service.Exceptions;
using FastFood.Service.Interfaces.Addresses;
using FastFood.Service.Interfaces.Order;
using FastFood.Service.Interfaces.Orders;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Service.Services.Orders
{
    public class OrderActionService : IOrderActionService
    {
        private readonly IOrderService orderService;
        private readonly IAddressService addressService;
        private readonly IRepository<OrderAction> actionRepository;
        private readonly IRepository<OrderItem> orderItemRepository;

        public OrderActionService(IRepository<OrderItem> orderItemRepository, IAddressService addressService, IRepository<OrderAction> actionRepository, IOrderService orderService)
        {
            this.orderItemRepository = orderItemRepository;
            this.addressService = addressService;
            this.actionRepository = actionRepository;
            this.orderService = orderService;
        }

        public async ValueTask<OrderForResultDto> CancelledAsync(long orderId)
        {
            var order = await this.orderService.RetrieveAsync(orderId);
            if (order is null)
                throw new CustomException(404, "Order is not found");

            var orderItems = await this.orderItemRepository.SelectAllAsync(o => o.OrderId == orderId).ToListAsync();

            order.Id = orderId;
            order.Status = OrderStatus.Cancelled;
            await this.actionRepository.InsertAsync(new OrderAction() { OrderId = orderId, Status = OrderStatus.Cancelled });
            return order;
        }

        public async ValueTask<OrderForResultDto> FinishDeliveryAsync(long orderId)
        {
            var order = await this.orderService.RetrieveAsync(orderId);
            if (order is null)
                throw new CustomException(404, "Order is not found");

            order.Id = orderId;
            order.Status = OrderStatus.Shipped;

            await this.actionRepository.InsertAsync(new OrderAction() { OrderId = orderId, Status = OrderStatus.Shipped });
            return order;

        }

        public async ValueTask<OrderForResultDto> StartPendingAsync(long orderId)
        {
            var order = await this.orderService.RetrieveAsync(orderId);
            if (order is null)
                throw new CustomException(404, "Order is not found");

            order.Status = OrderStatus.Pending;

            await this.actionRepository.InsertAsync(new OrderAction() { OrderId = orderId, Status = OrderStatus.Pending });
            return order;
        }

        public async ValueTask<OrderForResultDto> StartPreparingAsync(long orderId)
        {
            var order = await this.orderService.RetrieveAsync(orderId);
            if (order is null)
                throw new CustomException(404, "Order is not found");

            order.Status = OrderStatus.Process;

            await this.actionRepository.InsertAsync(new OrderAction() { OrderId = orderId, Status = OrderStatus.Process});
            return order;
        }

        public async ValueTask<OrderForResultDto> StartShippingAsync(long orderId)
        {
            var order = await this.orderService.RetrieveAsync(orderId);
            if (order is null)
                throw new CustomException(404, "Order is not found");

            var address = await this.addressService.RetrieveAsync(order.AddressId);

            order.Status = OrderStatus.Shipping;
            await this.actionRepository.InsertAsync(new OrderAction() { OrderId = order.Id, Status = OrderStatus.Shipping });
            return order;
        }
    }
}
