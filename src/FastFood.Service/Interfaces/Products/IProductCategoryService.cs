using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.ProductDto;

namespace FastFood.Service.Interfaces.Products
{
    public interface IProductCategoryService
    {
        Task<ProductCategoryForResultDto> AddAsync(ProductCategoryForCreationDto dto);
        Task<ProductCategoryForResultDto> ModifyAsync(long id, ProductCategoryForUpdateDto dto);
        Task<bool> RemoveAsync(long id);
        Task<ProductCategoryForResultDto> RetrieveAsync(long id);
        Task<IEnumerable<ProductCategoryForResultDto>> RetrieveAllAsync(PaginationParams @params);
    }
}
