using AutoMapper;
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

        public async ValueTask<ProductForResultDto> AddAsync(ProductForCreationDto model)
        {
            var entity = await productRepository.SelectAsync(x => x.Name == model.Name);
            if (entity is not null)
                throw new CustomException(405, "Product already exist");

            Product mappedProduct = this.mapper.Map<Product>(model);

            try
            {
                var result = await this.productRepository.InsertAsync(mappedProduct);
                await this.productRepository.SaveChangesAsync();

                return this.mapper.Map<ProductForResultDto>(result);
            }

            catch (Exception)
            {
                throw new CustomException(500, "Something went wrong");
            }
        }

        public async ValueTask<bool> RemoveAsync(long id)
        {
            var entity = await productRepository.SelectAsync(x => x.Id == id);
            if (entity is not null)
                throw new CustomException(404, "Product not found");

            var model = await productRepository.DeleteAsync(x => x == entity);
            await productRepository.SaveChangesAsync();
            return model;
        }

        public async ValueTask<ProductForResultDto> ModifyAsync(long id,ProductForUpdateDto model)
        {
            var entity = await productRepository.SelectAsync(x=>x.Id == id);
            if (entity is null)
                throw new CustomException(404, "Product not found");

            var mapped = mapper.Map(model, entity);
            mapped.Update();

            await productRepository.UpdateAsync(mapped);
            await productRepository.SaveChangesAsync();
            return mapper.Map<ProductForResultDto>(mapped);
        }

        public IEnumerable<ProductForResultDto> RetrieveAll(PaginationParams @params)
        {
            var products = this.productRepository.SelectAllAsync(p => !p.IsDeleted)
                .ToPagedList(@params)
                .ToList();

            return mapper.Map<IEnumerable<ProductForResultDto>>(products);
        }

        public async ValueTask<ProductForResultDto> RetrieveAsync(long id)
        {
            var entity = await productRepository.SelectAsync(x => x.Id == id);
            return mapper.Map<ProductForResultDto>(entity);
        }
    }
}
