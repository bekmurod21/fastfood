using AutoMapper;
using FastFood.Service.DTOs.UserDto;
using FastFood.Domain.Entities.Users;
using FastFood.Service.DTOs.OrderDto;
using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Entities.Payments;
using FastFood.Service.DTOs.AddressDto;
using FastFood.Service.DTOs.PaymentDto;
using FastFood.Service.DTOs.ProductDto;
using FastFood.Domain.Entities.Products;
using FastFood.Service.DTOs.Feedbacks;
using FastFood.Domain.Entities.Orders.Feedbacks;
using FastFood.Domain.Entities.Authorizations;
using FastFood.Service.DTOs.RoleDto;
using FastFood.Service.DTOs.PermissionDto;
using FastFood.Service.DTOs.RolePermissionDto;
using FastFood.Service.DTOs.CartDto;

namespace FastFood.Service.Mappers
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Role, RoleForCreationDto>().ReverseMap();
            CreateMap<RoleForResultDto, Role>().ReverseMap();
            CreateMap<RoleForUpdateDto, Role>().ReverseMap();

            CreateMap<PermissionForCreationDto, Permission>().ReverseMap();
            CreateMap<PermissionForResultDto, Permission>().ReverseMap();
            CreateMap<PermissionForUpdateDto,Permission>().ReverseMap();

            CreateMap<RolePermissionForCreationDto, Permission>().ReverseMap();
            CreateMap<RolePermissionForResultDto, Permission>().ReverseMap();
            CreateMap<RolePermissionForUpdateDto, Permission>().ReverseMap();

            CreateMap<CartForResultDto,Cart>().ReverseMap();
            CreateMap<CartItemForCreationDto,CartItem>().ReverseMap();
            CreateMap<CartItemForResultDto,CartItem>().ReverseMap();
            CreateMap<CartItemForUpdateDto, CartItem>().ReverseMap();

            CreateMap<FeedbackForResultDto, Feedback>().ReverseMap();
            CreateMap<FeedbackForCreationDto, Feedback>().ReverseMap();
            CreateMap<FeedbackForUpdateDto, Feedback>().ReverseMap();

            CreateMap<OrderItemForCreationDto, OrderItem>().ReverseMap();
            CreateMap<OrderItemForResultDto, OrderItem>().ReverseMap();
            CreateMap<OrderForCreationDto,Order>().ReverseMap();
            CreateMap<OrderForResultDto,Order>().ReverseMap();
            CreateMap<OrderProductForCreationDto, OrderProduct>().ReverseMap();

            CreateMap<PaymentForResultDto,Payment>().ReverseMap();
            CreateMap<PaymentForCreationDto,Payment>().ReverseMap();

            CreateMap<ProductForResultDto,Product>().ReverseMap();
            CreateMap<ProductForUpdateDto, Product>().ReverseMap();
            CreateMap<ProductForCreationDto, Product>().ReverseMap();
            CreateMap<ProductCategoryForCreationDto, ProductCategory>().ReverseMap();
            CreateMap<ProductCategoryForResultDto, ProductCategory>().ReverseMap();
            CreateMap<ProductCategoryForUpdateDto,ProductCategory>().ReverseMap();
            
            CreateMap<UserForResultDto,User>().ReverseMap();
            CreateMap<UserForUpdateDto,UserForResultDto>().ReverseMap();
            CreateMap<UserForCreationDto,User>().ReverseMap();
            CreateMap<Address, AddressForResultDto>().ReverseMap();
            CreateMap<AddressForCreationDto,Address>().ReverseMap();
        }
    }
}
