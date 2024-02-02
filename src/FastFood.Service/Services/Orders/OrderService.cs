using AutoMapper;
using FastFood.Domain.Enums;
using FastFood.Domain.Helpers;
using FastFood.Service.Exceptions;
using FastFood.Data.IRepositories;
using FastFood.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.OrderDto;
using FastFood.Domain.Entities.Users;
using FastFood.Domain.Entities.Orders;
using FastFood.Service.Interfaces.Orders;
using FastFood.Service.Interfaces.Addresses;

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
        IRepository<CartItem> cartItemRepository, IAddressService addressService)
    {
        this.mapper = mapper;
        this.paymentService = paymentService;
        this.cartRepository = cartRepository;
        this.userRepository = userRepository;
        this.orderRepository = orderRepository;
        this.cartItemRepository = cartItemRepository;
        this.addressService = addressService;
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
        }

        var insertedOrder = await orderRepository.InsertAsync(order);
        return mapper.Map<OrderForResultDto>(insertedOrder);

    }

    public async ValueTask<bool> RemoveAsync(long id)
    {
        var isDeleted = await orderRepository.DeleteAsync(order => order.Id == id);
        if (!isDeleted)
            throw new CustomException(404, "Order is not found");

        return isDeleted;
    }

    public async ValueTask<IEnumerable<OrderForResultDto>> RetrieveAllAsync(PaginationParams @params, OrderStatus? status = null)
    {
        var orders = orderRepository.SelectAllAsync(order => !order.IsDeleted,
            new string[] { "User", "Address", "OrderItem" }).AsQueryable();

        if(status != null)
            orders = orders.Where(order => order.Status == status);

        if (!orders.Any())
            throw new CustomException(400, "no Order found");

        var pagedOrder = await orders.ToPagedList(@params)
            .ToListAsync();
        return mapper.Map<IEnumerable<OrderForResultDto>>(pagedOrder);
    }

    public async ValueTask<IEnumerable<OrderForResultDto>> RetrieveAllByClientIdAsync(long clientId)
    {
        var orders = await this.orderRepository.SelectAllAsync(order => !order.IsDeleted && order.UserId == clientId, new string[] { "User", "Address", "OrderItem" }).ToListAsync();

        if (!orders.Any())
            throw new CustomException(400, "No order found");
        return mapper.Map<IEnumerable<OrderForResultDto>>(orders);
    }

    public async ValueTask<IEnumerable<OrderForResultDto>> RetrieveAllByPhoneAsync(PaginationParams @params, string phone, OrderStatus? status = null)
    {
        var user = await userRepository.SelectAsync(user => !user.IsDeleted && user.Phone == phone,
           new string[] { "Orders.OrderItems" });
        if (user is null)
            throw new CustomException(404, "User is not found");

        var ordersQuery = orderRepository
            .SelectAllAsync(order => !order.IsDeleted && order.UserId == user.Id);
        if (status is not null)
            ordersQuery = ordersQuery.Where(order => order.Status == status);

        ordersQuery = (IQueryable<Order>)ordersQuery.ToPagedList(@params);

        var orders = await ordersQuery.ToListAsync();

        // checking something exists or not
        if (!orders.Any())
            throw new CustomException(400, "No orders found.");

        return mapper.Map<IEnumerable<OrderForResultDto>>(orders);
    }

    public async ValueTask<OrderForResultDto> RetrieveAsync(long id)
    {
        var order = await orderRepository.SelectAsync(order => !order.IsDeleted && order.Id == id,
            new string[] {"User","Address","OrderItem"});
        if (order == null)
            throw new CustomException(404, "Order not found");
        return mapper.Map<OrderForResultDto>(order);
    }
}
