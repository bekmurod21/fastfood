﻿using AutoMapper;
using FastFood.Data.IRepositories;
using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Products;
using FastFood.Domain.Entities.Users;
using FastFood.Service.DTOs.ProductDto;
using FastFood.Service.Exceptions;
using FastFood.Service.Extensions;
using FastFood.Service.Interfaces;
using System.Linq.Expressions;

namespace FastFood.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IMapper mapper;
        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async ValueTask<Product> AddAsync(ProductForCreationDto model)
        {
            var entity = await productRepository.GetAsync(x => x.Name == model.Name);
            if (entity is not null)
                throw new CustomException(405, "Product already exist");

            await productRepository.CreateAsync(entity);
            await productRepository.SaveChangesAsync();
            return entity;
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var entity = await productRepository.GetAsync(x => x.Id == id);
            if (entity is not null)
                throw new CustomException(404, "Product not found");

            var model = await productRepository.DeleteAsync(x => x == entity);
            await productRepository.SaveChangesAsync();
            return model;
        }

        public async ValueTask<Product> ModifyAsync(long id, ProductForCreationDto model)
        {
            var entity = await productRepository.GetAsync(x=>x.Id == id);
            if (entity is null)
                throw new CustomException(404, "Product not found");

            var mapped = mapper.Map(model, entity);
            mapped.Update();

            await productRepository.UpdateAsync(mapped, id);
            await productRepository.SaveChangesAsync();
            return mapped;
        }

        public IEnumerable<Product> SelectAllAsync(PaginationParams @params, Expression<Func<Product, bool>> expression = null)
        {
            var products =
            this.productRepository.GetAllAsync(expression).ToPaged(@params);

            return products.ToList();
        }

        public async ValueTask<Product> SelectAsync(long id)
        {
            var entity = await productRepository.GetAsync(x => x.Id == id);
            return entity;
        }
    }
}