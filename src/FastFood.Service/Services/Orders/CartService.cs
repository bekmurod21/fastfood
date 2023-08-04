using AutoMapper;
using FastFood.Service.Helpers;
using FastFood.Service.Extensions;
using FastFood.Service.Exceptions;
using FastFood.Data.IRepositories;
using FastFood.Service.DTOs.CartDto;
using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Entities.Products;
using FastFood.Service.Interfaces.Order;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Service.Services.Orders
{
    public class CartService : ICartService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Cart> cartRepository;
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<CartItem> cartItemRepository;
        public CartService(IRepository<Product> productRepository,
            IRepository<CartItem> cartItemRepository,
            IRepository<Cart> cartRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.cartItemRepository = cartItemRepository;
            this.cartRepository = cartRepository;
            this.mapper = mapper;
        }


        public async ValueTask<CartItemForResultDto> AddAsync(CartItemForCreationDto dto)
        {
            var product = await this.productRepository.SelectAsync(p => p.Id == dto.ProductId && !p.IsDeleted);
            if (product is null)
                throw new CustomException(404, "Product not found");

            var cart = await this.cartRepository.SelectAsync(cart => cart.UserId == HttpContextHelper.UserId);
            if (cart is null)
                throw new CustomException(404, "Cart not found");

            var cartItem = new CartItem()
            {
                Amount = dto.Amount,
                CartId = cart.Id,
                ProductId = dto.ProductId,
                AmountTotal = product.Price * dto.Amount
            };

            var insertedCartItem = this.cartItemRepository.InsertAsync(cartItem);
            return mapper.Map<CartItemForResultDto>(insertedCartItem);
        }

        public async ValueTask<CartItemForResultDto> ModifyAsync(CartItemForUpdateDto dto)
        {
            var cartItem = await this.cartItemRepository
            .SelectAsync(item => !item.IsDeleted && !item.IsOrdered && item.Id == dto.Id,
            includes: new string[] { "Product" });
            if (cartItem is null)
                throw new CustomException(404, "Cart item not found");

            cartItem.Amount = dto.Amount;
            cartItem.AmountTotal = cartItem.Product.Price * dto.Amount;
            cartItem.UpdatedBy = HttpContextHelper.UserId;
            cartItem.UpdatedAt = DateTime.UtcNow;
            var result = this.cartItemRepository.UpdateAsync(cartItem);

            return this.mapper.Map<CartItemForResultDto>(result);
        }

        public async ValueTask<bool> RemoveAsync(long id)
        {
            var cartItem = await this.cartItemRepository.SelectAsync(item => !item.IsDeleted && !item.IsOrdered && item.Id == id);
            if (cartItem is null)
                throw new CustomException(404, "CartItem not found");

            cartItem.DeletedBy = HttpContextHelper.UserId;
            cartItem.DeletedAt = DateTime.UtcNow;
            var deleted = await this.cartItemRepository.DeleteAsync(item=>item.Id==id);
            return deleted;
        }

        public async ValueTask<IEnumerable<CartItemForResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            var itemsQuery = this.cartItemRepository
             .SelectAllAsync(item => !item.IsDeleted && !item.IsOrdered && item.Cart.UserId == HttpContextHelper.UserId,
             includes: new string[] { "Product" });


            var items = await itemsQuery.ToPagedList(@params).ToListAsync();

            return this.mapper.Map<IEnumerable<CartItemForResultDto>>(items);
        }

        public async ValueTask<CartForResultDto> RetrieveByClientIdAsync()
        {
            var cart = await this.cartRepository
            .SelectAsync(item => !item.IsDeleted && item.UserId == HttpContextHelper.UserId,
            includes: new string[] { "Items" });
            if (cart is null)
                throw new CustomException(404, "Cart item not found.");

            return this.mapper.Map<CartForResultDto>(cart);
        }

        public async ValueTask<CartItemForResultDto> RetrieveByIdAsync(long id)
        {
            var cartItem = await this.cartItemRepository
            .SelectAsync(item => !item.IsDeleted && !item.IsOrdered && item.Id == id,
            includes: new string[] { "Product" });
            if (cartItem is null)
                throw new CustomException(404, "Cart item not found.");

            return this.mapper.Map<CartItemForResultDto>(cartItem);
        }
    }
}
