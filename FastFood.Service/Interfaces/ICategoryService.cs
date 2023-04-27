using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Products;
using FastFood.Service.DTOs.ProductDto;
using System.Linq.Expressions;

namespace FastFood.Service.Interfaces
{
    public interface ICategoryService
    {
        ValueTask<ProductCategory> AddAsync(CategoryForCreationDto model);
        ValueTask<ProductCategory> ModifyAsync(long id, CategoryForCreationDto model);
        ValueTask<bool> DeleteAsync(Expression<Func<ProductCategory, bool>> expression);
        ValueTask<ProductCategory> SelectAsync(Expression<Func<ProductCategory, bool>> expression);
        IEnumerable<ProductCategory> SelectAllAsync(
            PaginationParams @params,
            Expression<Func<ProductCategory, bool>> expression=null
            );
    }
}
