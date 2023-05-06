using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Products;
using FastFood.Domain.Entities.Users;
using FastFood.Service.DTOs.ProductDto;
using System.Linq.Expressions;

namespace FastFood.Service.Interfaces;

public interface IProductService
{
    ValueTask<Product> AddAsync(ProductForCreationDto model);
    ValueTask<Product> ModifyAsync(long id,ProductForCreationDto model);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Product> SelectAsync(long id);
    IEnumerable<Product> SelectAllAsync(PaginationParams @params, Expression<Func<Product, bool>> expression = null);
}
