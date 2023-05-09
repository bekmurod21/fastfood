using AutoMapper;
using FastFood.Data.IRepositories;
using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Users;
using FastFood.Service.DTOs.UserDto;
using FastFood.Service.Exceptions;
using FastFood.Service.Extensions;
using FastFood.Service.Interfaces;
using System.Linq.Expressions;

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
            User user = await this.userRepository.GetAsync(u => u.UserName.ToLower() == model.UserName.ToLower());

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

        public IEnumerable<User> SelectAll(PaginationParams @params, Expression<Func<User, bool>> expression = null)
        {
            var users =
            this.userRepository.GetAllAsync(expression).ToPaged(@params);

            return users.ToList();
        }

        public async ValueTask<User> SelectAsync(long id)
        {
            var entity = await userRepository.GetAsync(x => x.Id == id);
            if (entity is null)
                throw new CustomException(404, "User not found");

            return entity;
        }
    }
}
