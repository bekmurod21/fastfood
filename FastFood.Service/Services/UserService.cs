using AutoMapper;
using FastFood.Data.IRepositories;
using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Users;
using FastFood.Service.DTOs.UserDto;
using FastFood.Service.Exceptions;
using FastFood.Service.Extensions;
using FastFood.Service.Interfaces;
using System.Linq.Expressions;
using MailKit.Net.Imap;
using FastFood.Service.Helpers;

namespace FastFood.Service.Services
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
            User user = await this.userRepository.SelectAsync(u => u.UserName.ToLower() == model.UserName.ToLower());

            if (user is not null)
                throw new CustomException(403, "User already exist with this username");

            User mappedUser = mapper.Map<User>(model);

            try
            {
                var result = await this.userRepository.InsertAsync(mappedUser);
                await this.userRepository.SaveChangesAsync();

                return this.mapper.Map<UserForResultDto>(result);
            }

            catch (Exception)
            {
                throw new CustomException(500, "Something went wrong");
            }
        }

        public async ValueTask<bool> RemoveAsync(long id)
        {
            var entity = await userRepository.SelectAsync(x=>x.Id==id);
            if(entity is null || entity.IsDeleted)
                throw new CustomException(404, "User not found");

            entity.DeletedBy = HttpContextHelper.UserId;

            await this.userRepository.DeleteAsync(u => u.Id == id);

            await this.userRepository.SaveChangesAsync();

            return true;
        }

        

        public async ValueTask<UserForResultDto> ModifyAsync(long id, UserForUpdateDto model)
        {
            var entity = await userRepository.SelectAsync(x => x.Id == id);
            if (entity is null)
                throw new CustomException(404, "User not found");

            entity.UpdatedAt = DateTime.UtcNow;
            var mappedUser = this.mapper.Map(model,entity);
            mappedUser.Update();

            await userRepository.UpdateAsync(mappedUser);
            await userRepository.SaveChangesAsync();

            return this.mapper.Map<UserForResultDto>(mappedUser);
        }

        public async ValueTask<IEnumerable<UserForResultDto>> RetrieveAll(PaginationParams @params)
        {
            var users = this.userRepository.SelectAllAsync(u => !u.IsDeleted)
                .ToPagedList(@params)   
                .ToList();

            return this.mapper.Map<IEnumerable<UserForResultDto>>(users);
        }

        public async ValueTask<UserForResultDto> RetrieveAsync(long id)
        {
            var entity = await userRepository.SelectAsync(x => x.Id == id);
            if (entity is null)
                throw new CustomException(404, "User not found");

            return this.mapper.Map<UserForResultDto>(entity);
        }
    }
}
