using AutoMapper;
using FastFood.Domain.Helpers;
using FastFood.Data.IRepositories;
using FastFood.Service.Exceptions;
using FastFood.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.ProductDto;
using FastFood.Domain.Entities.Products;
using FastFood.Service.Interfaces.Products;

namespace FastFood.Service.Services.Products
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepository<ProductCategory> repository;
        private readonly IMapper mapper;

        public ProductCategoryService(IRepository<ProductCategory> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ProductCategoryForResultDto> AddAsync(ProductCategoryForCreationDto dto)
        {
            var productCategory = await this.repository.SelectAsync(p => p.Name.ToLower() == dto.Name.ToLower() && !p.IsDeleted);
            if (productCategory is not null)
                throw new CustomException(401, "Product category already exist.");

            var mappedCategory = this.mapper.Map<ProductCategory>(dto);
            mappedCategory.CreatedAt = DateTime.UtcNow;
            var addedCategory = await this.repository.InsertAsync(mappedCategory);
            return this.mapper.Map<ProductCategoryForResultDto>(addedCategory);
        }

        public async Task<ProductCategoryForResultDto> ModifyAsync(long id, ProductCategoryForUpdateDto dto)
        {
            var category = await this.repository.SelectAsync(p => p.Id == id && !p.IsDeleted);
            if (category is null)
                throw new CustomException(404, "Product Category is not found");

            var modifiedCategory = this.mapper.Map(dto, category);
            modifiedCategory.UpdatedAt = DateTime.UtcNow;
            modifiedCategory.UpdatedBy = HttpContextHelper.UserId;

            return this.mapper.Map<ProductCategoryForResultDto>(modifiedCategory);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var category = await this.repository.SelectAsync(p => p.Id == id && !p.IsDeleted);
            if (category is null)
                throw new CustomException(404, "Product Category is not found");

            bool result = await this.repository.DeleteAsync(p => p.Id == id);

            return result;
        }

        public async Task<IEnumerable<ProductCategoryForResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            var categories = await this.repository
            .SelectAllAsync(p => !p.IsDeleted)
            .ToPagedList(@params)
            .ToListAsync();

            return this.mapper.Map<IEnumerable<ProductCategoryForResultDto>>(categories);
        }

        public async Task<ProductCategoryForResultDto> RetrieveAsync(long id)
        {
            var category = await this.repository.SelectAsync(p => p.Id == id && !p.IsDeleted);
            if (category is null)
                throw new CustomException(404, "Product Category not found");

            return this.mapper.Map<ProductCategoryForResultDto>(category);
        }
    }
}
