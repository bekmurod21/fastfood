using AutoMapper;
using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Entities.Products;
using FastFood.Domain.Entities.Users;
using FastFood.Service.DTOs.OrderDto;
using FastFood.Service.DTOs.ProductDto;
using FastFood.Service.DTOs.UserDto;

namespace FastFood.Service.Mappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderForCreationDto,Order>().ReverseMap();
            CreateMap<OrderProductForCreationDto, OrderProduct>().ReverseMap();
            CreateMap<PaymentForCreationDto,Payment>().ReverseMap();

            CreateMap<CategoryForCreationDto,ProductCategory>().ReverseMap();
            CreateMap<ProductForCreationDto, Product>().ReverseMap();
            CreateMap<ProductForViewModel,Product>().ReverseMap();

            CreateMap<AddressForCreationDto,Address>().ReverseMap();
            CreateMap<UserForCreationDto,User>().ReverseMap();
        }
    }
}
