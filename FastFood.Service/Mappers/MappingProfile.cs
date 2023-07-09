﻿using AutoMapper;
using FastFood.Service.DTOs.UserDto;
using FastFood.Domain.Entities.Users;
using FastFood.Service.DTOs.OrderDto;
using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Entities.Payment;
using FastFood.Service.DTOs.AddressDto;
using FastFood.Service.DTOs.PaymentDto;
using FastFood.Service.DTOs.ProductDto;
using FastFood.Domain.Entities.Products;

namespace FastFood.Service.Mappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderForCreationDto,Order>().ReverseMap();
            CreateMap<PaymentForCreationDto,Payment>().ReverseMap();
            CreateMap<PaymentForResultDto,Payment>().ReverseMap();
            CreateMap<OrderProductForCreationDto, OrderProduct>().ReverseMap();

            CreateMap<ProductForResultDto,Product>().ReverseMap();
            CreateMap<ProductForUpdateDto, Product>().ReverseMap();
            CreateMap<ProductForCreationDto, Product>().ReverseMap();
            
            CreateMap<UserForResultDto,User>().ReverseMap();
            CreateMap<UserForUpdateDto,UserForResultDto>().ReverseMap();
            CreateMap<UserForCreationDto,User>().ReverseMap();
            CreateMap<AddressForCreationDto,Address>().ReverseMap();
        }
    }
}
