using AutoMapper;
using FastFood.Data.IRepositories;
using FastFood.Domain.Entities.Users;
using FastFood.Service.DTOs.UserDto;
using FastFood.Service.Exceptions;
using FastFood.Service.Extensions;
using FastFood.Service.Interfaces;

namespace FastFood.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IMapper mapper;
        public UserService(IRepository<User> repository, IMapper mapper)
        {
            this.userRepository = repository;
            this.mapper = mapper;
        }
        public async ValueTask<User> AddAsync(UserForCreationDto model)
        {
            User user = await this.userRepository.GetAsync(u => u.UserName.ToLower() == model.Login.ToLower());

            if (user is not null)
                throw new CustomException(403, "User already exist with this username");

            User mappedUser = mapper.Map<User>(model);

            try
            {
                var result = await this.userRepository.CreateAsync(mappedUser);
                await this.userRepository.SaveChangesAsync();

                return this.mapper.Map<User>(result);
            }

            catch (Exception)
            {
                throw new CustomException(500, "Something went wrong");
            }
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var entity = await userRepository.GetAsync(x=>x.Id==id);
            if(entity is null)
                throw new CustomException(404, "User not found");
            return await userRepository.DeleteAsync(x => x == entity);
        }

        public IEnumerable<User> GetAllAsync()
        {
            return userRepository.GetAllAsync();
        }

        public async ValueTask<User> ModifyAsync(long id, UserForCreationDto model)
        {
            User entity = await userRepository.GetAsync(x => x.Id == id);
            if (entity is null)
                throw new CustomException(404, "User not found");

            entity.UpdatedAt = DateTime.UtcNow;
            var mappedUser = this.mapper.Map(model,entity);
            mappedUser.Update();

            await userRepository.UpdateAsync(mappedUser,id);
            await userRepository.SaveChangesAsync();

            return mappedUser;
        }

        public ValueTask<User> SelectAsync(long id)
        {
            var entity = userRepository.GetAsync(x => x.Id == id);
            if (entity == null)
                throw new CustomException(404, "User not found");

            return entity;
        }
    }
}
