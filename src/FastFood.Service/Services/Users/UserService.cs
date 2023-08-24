using AutoMapper;
using FastFood.Data.Contexts;
using FastFood.Domain.Helpers;
using FastFood.Data.IRepositories;
using FastFood.Service.Extensions;
using FastFood.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using FastFood.Service.DTOs.UserDto;
using FastFood.Domain.Entities.Users;
using FastFood.Domain.Configurations;
using FastFood.Domain.Entities.Orders;
using FastFood.Service.Interfaces.Users;
using FastFood.Domain.Entities.Authorizations;

namespace FastFood.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Cart> cartRepository;
        private readonly IRepository<Role> roleRepository;
        private readonly AppDbContext dbContext;
        public UserService(IMapper mapper,
        IRepository<User> userRepository,
        IRepository<Cart> cartRepository,
        IRepository<Role> roleRepository,
        AppDbContext dbContext)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.cartRepository = cartRepository;
            this.roleRepository = roleRepository;
            this.dbContext = dbContext;
        }
        public async ValueTask<UserForResultDto> AddAsync(UserForCreationDto model)
        {
            User user = await userRepository.SelectAsync(u => u.Phone == model.Phone);
            if (user is not null && !user.IsDeleted)
                throw new CustomException(403, "User already exist with this username");

            var userRole = await this.roleRepository.SelectAsync(t => t.Name.ToLower() == "user");
            User mappedUser = mapper.Map<User>(model);
            mappedUser.RoleId = userRole.Id;
            mappedUser.CreatedAt = DateTime.UtcNow;
            mappedUser.Password = PasswordHelper.Hash(model.Password);


            try
            {
                var result = await userRepository.InsertAsync(mappedUser);

                var newCart = new Cart();
                newCart.UserId = result.Id;
                await cartRepository.InsertAsync(newCart);

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

            var accessor = HttpContextHelper.Accessor;
            entity.DeletedBy = HttpContextHelper.UserId;

            entity.DeletedAt = DateTime.UtcNow;
            await userRepository.DeleteAsync(u => u.Id == id);

            var cart = await this.cartRepository.SelectAsync(c => c.Id == entity.Id);
            if (cart is not null)
                await cartRepository.DeleteAsync(c => c.Id == cart.Id);

            return true;
        }
        public async ValueTask<UserForResultDto> ModifyAsync(long id, UserForUpdateDto model)
        {
            var entity = await userRepository.SelectAsync(x => x.Id == id);
            if (entity is null || entity.IsDeleted)
                throw new CustomException(404, "User not found");

            var mappedUser = mapper.Map(model, entity);
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
            if (entity is null||entity.IsDeleted)
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
        public async Task<UserForResultDto> ChangePasswordAsync(UserForChangePasswordDto dto)
        {
            var user = await this.userRepository.SelectAsync(u => u.Email == dto.Email);
            if (user is null || user.IsDeleted == true)
                throw new CustomException(404, "User is not found");

            if (!PasswordHelper.Verify(dto.OldPassword, user.Password))
                throw new CustomException(400, "Old password is incorrect");

            if (dto.NewPassword != dto.ConfirmPassword)
                throw new CustomException(400, "New password doesn't equal confirm password");

            user.Password = PasswordHelper.Hash(dto.NewPassword);
            user.Update();
            await dbContext.SaveChangesAsync();
            return mapper.Map<UserForResultDto>(user);
        }

        public async ValueTask<User> RetrieveByLoginAsync(string login)
        {
            var phone = await this.userRepository.SelectAsync(u=>u.Phone == login && !u.IsDeleted);
            if (phone is not null)
                return phone;
            var username = await this.userRepository.SelectAsync(u=>u.UserName == login && !u.IsDeleted);
            if (username is not null)
                return username;
            var email = await this.userRepository.SelectAsync(u=>u.Email == login && !u.IsDeleted);
            if (username is not null)
                return email;
            if (email is null || phone is null || username is null)
                throw new CustomException(404, "User is not found");
            return email;
        }
    }
}
