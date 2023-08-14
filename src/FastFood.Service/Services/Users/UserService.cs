using AutoMapper;
using FastFood.Service.Helpers;
using FastFood.Data.IRepositories;
using FastFood.Service.Extensions;
using FastFood.Service.Exceptions;
using FastFood.Service.DTOs.UserDto;
using FastFood.Domain.Entities.Users;
using FastFood.Domain.Configurations;
using Microsoft.EntityFrameworkCore;
using FastFood.Service.Interfaces.Users;

namespace FastFood.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IMapper mapper;
        public UserService(IMapper mapper,
        IRepository<User> userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
        public async ValueTask<UserForResultDto> AddAsync(UserForCreationDto model)
        {
            User user = await userRepository.SelectAsync(u => u.UserName.ToLower() == model.UserName.ToLower());

            if (user is not null || !user.IsDeleted)
                throw new CustomException(403, "User already exist with this username");

            User mappedUser = mapper.Map<User>(model);

            try
            {
                var result = await userRepository.InsertAsync(mappedUser);

                return mapper.Map<UserForResultDto>(result);
            }

            catch (Exception)
            {
                throw new CustomException(500, "Something went wrong");
            }
        }

        public async ValueTask<bool> RemoveAsync(long id)
        {
            var entity = await userRepository.SelectAsync(x => x.Id == id);
            if (entity is null || entity.IsDeleted)
                throw new CustomException(404, "User not found");

            entity.DeletedAt = DateTime.UtcNow;
            entity.DeletedBy = HttpContextHelper.UserId;
            await userRepository.DeleteAsync(u => u.Id == id);


            return true;
        }



        public async ValueTask<UserForResultDto> ModifyAsync(long id, UserForUpdateDto model)
        {
            var entity = await userRepository.SelectAsync(x => x.Id == id);
            if (entity is null || entity.IsDeleted)
                throw new CustomException(404, "User not found");

            var mappedUser = mapper.Map(model, entity);
            mappedUser.UpdatedAt = DateTime.UtcNow;
            mappedUser.UpdatedBy = HttpContextHelper.UserId;
            mappedUser.Update();

            await userRepository.UpdateAsync(mappedUser);
            return mapper.Map<UserForResultDto>(mappedUser);
        }

        public async ValueTask<IEnumerable<UserForResultDto>> RetrieveAll(PaginationParams @params)
        {
            var users = await userRepository.SelectAllAsync(u => !u.IsDeleted)
                .ToPagedList(@params)
                .ToListAsync();

            return mapper.Map<IEnumerable<UserForResultDto>>(users);
        }

        public async ValueTask<UserForResultDto> RetrieveAsync(long id)
        {
            var entity = await userRepository.SelectAsync(x => x.Id == id);
            if (entity is null)
                throw new CustomException(404, "User not found");

            return mapper.Map<UserForResultDto>(entity);
        }

        public async ValueTask<User> RetrieveByEmailAsync(string email)
        {
            var entity = await userRepository.SelectAsync(u=>u.Email == email);
            if (entity is null && entity.IsDeleted == false)
                throw new CustomException(404, "User is not found");

            return entity;
        }
    }
}
