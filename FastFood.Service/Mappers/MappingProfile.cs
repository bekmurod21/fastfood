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
            CreateMap<PaymentForCreationDto,Payment>().ReverseMap();
            CreateMap<OrderProductForCreationDto, OrderProduct>().ReverseMap();

            CreateMap<ProductForResultDto,Product>().ReverseMap();
            CreateMap<ProductForViewModel,Product>().ReverseMap();
            CreateMap<ProductForUpdateDto, Product>().ReverseMap();
            CreateMap<ProductForCreationDto, Product>().ReverseMap();
            CreateMap<CategoryForCreationDto,ProductCategory>().ReverseMap();

            CreateMap<UserForResultDto,User>().ReverseMap();
            CreateMap<UserForUpdateDto,UserForResultDto>().ReverseMap();
            CreateMap<UserForCreationDto,User>().ReverseMap();
            CreateMap<AddressForCreationDto,Address>().ReverseMap();
        }
    }
}
