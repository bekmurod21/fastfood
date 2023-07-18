using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.ProductDto;

namespace FastFood.Service.Interfaces;

public interface IProductService
{
    ValueTask<ProductForResultDto> AddAsync(ProductForCreationDto model);
    ValueTask<ProductForResultDto> ModifyAsync(long id,ProductForUpdateDto model);
    ValueTask<bool> RemoveAsync(long id);
    ValueTask<ProductForResultDto> RetrieveAsync(long id);
    Task<IEnumerable<ProductForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
