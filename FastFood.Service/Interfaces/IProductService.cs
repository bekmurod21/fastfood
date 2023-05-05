using FastFood.Domain.Entities.Products;
using FastFood.Service.DTOs.ProductDto;

namespace FastFood.Service.Interfaces;

public interface IProductService
{
    ValueTask<Product> AddAsync(ProductForCreationDto model);
    ValueTask<Product> ModifyAsync(long id,ProductForCreationDto model);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Product> SelectAsync(long id);
    IEnumerable<Product> SelectAllAsync();
}
