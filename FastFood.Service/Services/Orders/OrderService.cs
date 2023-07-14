using AutoMapper;
using FastFood.Domain.Enums;
using FastFood.Service.Helpers;
using FastFood.Service.Interfaces;
using FastFood.Data.IRepositories;
using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.OrderDto;
using FastFood.Service.Interfaces.Orders;
using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Entities.Users;
using FastFood.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Service.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IMapper mapper;
    private readonly IPaymentService paymentService;
    private readonly IAddressService addressService;
    private readonly IRepository<Cart> cartRepository;
    private readonly IRepository<CartItem> cartItemRepository;
    private readonly IRepository<User> userRepository;
    private readonly IRepository<Order> orderRepository;

    //private readonly 

    public OrderService(IMapper mapper, IRepository<Order> orderRepository,
        IPaymentService paymentService,
        IRepository<Cart> cartRepository,
        IRepository<User> userRepository,
        IRepository<CartItem> cartItemRepository)
    {
        this.mapper = mapper;
        this.paymentService = paymentService;
        this.cartRepository = cartRepository;
        this.userRepository = userRepository;
        this.orderRepository = orderRepository;
        this.cartItemRepository = cartItemRepository;
    }

    public async ValueTask<OrderForResultDto> AddAsync(OrderForCreationDto dto)
    {
        var address = await addressService.RetrieveAsync(dto.AddressId);

        var cart = await this.cartRepository.SelectAsync(c => c.UserId == HttpContextHelper.UserId,
            new string[] { "Items.Product" });
        if (cart == null)
            throw new CustomException(404, "Cart not found");
        var cartItems = await this.cartItemRepository.SelectAllAsync(item => !item.IsDeleted && 
            item.CartId == cart.Id &&
            !item.IsOrdered,
            includes: new string[] { "Product" }).ToListAsync();
        if (!cartItems.Any())
            throw new CustomException(404, "CartItems not found");

        var order = new Order()
        {
            UserId = HttpContextHelper.UserId ?? 0,
            AddressId = dto.AddressId,
            OrderItems = new List<OrderItem>()
        };

        foreach (var cartItem in cartItems)
        {
            order.OrderItems.Add(new OrderItem
            {
                Id = cartItem.Id,
                Amount = cartItem.Amount,
                AmountTotal = cartItem.AmountTotal,
                ProductId = cartItem.ProductId,
                CreatedAt = cartItem.CreatedAt
            });
            cartItem.IsOrdered = true;
            order.TotalAmount += cartItem.Product.Price;

        }

        var insertedOrder = await orderRepository.InsertAsync(order);
        return mapper.Map<OrderForResultDto>(insertedOrder);

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
