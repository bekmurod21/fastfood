using AutoMapper;
using FastFood.Data.IRepositories;
using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Enums;
using FastFood.Service.DTOs.OrderDto;
using FastFood.Service.Interfaces;

namespace FastFood.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IMapper mapper;
        //private readonly 

        public OrderService(IMapper mapper, IRepository<Order> orderRepository)
        {
            this.mapper = mapper;
            this.orderRepository = orderRepository;
        }

        public async ValueTask<OrderForResultDto> AddAsync(OrderForCreationDto dto)
        {
            var order = await orderRepository.SelectAsync(o=>o.UserId==dto.UserId);
        }

        public ValueTask<bool> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<OrderForResultDto>> RetrieveAllAsync(PaginationParams @params, OrderStatus? status = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<OrderForResultDto>> RetrieveAllByClientIdAsync(long clientId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<OrderForResultDto>> RetrieveAllByPhoneAsync(PaginationParams @params, string phone, OrderStatus? status = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<OrderForResultDto> RetrieveAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
