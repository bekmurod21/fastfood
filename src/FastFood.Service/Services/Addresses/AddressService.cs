using AutoMapper;
using FastFood.Service.Helpers;
using FastFood.Data.IRepositories;
using FastFood.Service.Exceptions;
using FastFood.Service.Extensions;
using FastFood.Domain.Entities.Users;
using FastFood.Domain.Configurations;
using FastFood.Service.DTOs.AddressDto;
using Microsoft.EntityFrameworkCore;
using FastFood.Service.Interfaces.Addresses;

namespace FastFood.Service.Services.Addresses
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> addressRepository;
        private readonly IMapper mapper;

        public AddressService(IRepository<Address> addressRepository, IMapper mapper)
        {
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }

        public async ValueTask<AddressForResultDto> AddAsync(AddressForCreationDto dto)
        {
            var address = mapper.Map<Address>(dto);
            address.CreatedAt = DateTime.UtcNow;
            address.CreatedBy = HttpContextHelper.UserId;
            var insertAddress = await addressRepository.InsertAsync(address);

            return mapper.Map<AddressForResultDto>(insertAddress);
        }

        public async ValueTask<AddressForResultDto> ModifyAsync(long id, AddressForCreationDto dto)
        {
            var address = await addressRepository.SelectAsync(a => a.Id == id);
            if (address is null)
                throw new CustomException(404, "Address not found");

            var mapped = mapper.Map<Address>(address);
            mapped.UpdatedBy = HttpContextHelper.UserId;
            mapped.UpdatedAt = DateTime.UtcNow;
            var updatedAddress = await addressRepository.UpdateAsync(mapped);
            return mapper.Map<AddressForResultDto>(updatedAddress);
        }

        public async ValueTask<bool> RemoveAsync(long id)
        {
            var address = await addressRepository.SelectAsync(a => a.Id == id);
            if (address is null || address.IsDeleted)
                throw new CustomException(404, "Address is found");
            address.DeletedBy = HttpContextHelper.UserId;
            address.DeletedAt = DateTime.UtcNow;
            return await addressRepository.DeleteAsync(a => a.Id == id);
        }

        public async ValueTask<IEnumerable<AddressForResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            var addresses = await addressRepository.SelectAllAsync(a => !a.IsDeleted)
                .ToPagedList(@params)
                .ToListAsync();

            return mapper.Map<IEnumerable<AddressForResultDto>>(addresses);
        }

        public async ValueTask<AddressForResultDto> RetrieveAsync(long id)
        {
            var entity = await addressRepository.SelectAsync(x => x.Id == id);
            if (entity is null)
                throw new CustomException(404, "Address not found");

            return mapper.Map<AddressForResultDto>(entity);
        }
    }
}
