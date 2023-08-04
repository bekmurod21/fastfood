using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.AddressDto;

namespace FastFood.Service.Interfaces
{
    public interface IAddressService
    {
        ValueTask<AddressForResultDto> AddAsync(AddressForCreationDto dto);
        ValueTask<AddressForResultDto> ModifyAsync(long id,AddressForCreationDto dto);
        ValueTask<bool> RemoveAsync(long id);
        ValueTask<AddressForResultDto> RetrieveAsync(long id);
        ValueTask<IEnumerable<AddressForResultDto>> RetrieveAllAsync(PaginationParams @params);
    }
}
