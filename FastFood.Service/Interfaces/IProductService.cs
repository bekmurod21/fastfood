using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Products;
using FastFood.Domain.Entities.Users;
using FastFood.Service.DTOs.ProductDto;
using System.Linq.Expressions;

namespace FastFood.Service.Interfaces;

public interface IProductService
{
    ValueTask<ProductForResultDto> AddAsync(ProductForCreationDto model);
    ValueTask<ProductForResultDto> ModifyAsync(long id,ProductForUpdateDto model);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<ProductForResultDto> RetrieveAsync(long id);
    IEnumerable<ProductForResultDto> RetrieveAll(PaginationParams @params);
}
