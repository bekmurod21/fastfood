using FastFood.Data.IRepositories;
using FastFood.Data.Repositories;
using FastFood.Service.Interfaces.Users;
using FastFood.Service.Services.Users;

namespace FastFood.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Add services
        /// </summary>
        /// <param name="services"></param>
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserService, UserService>();
        }
    }
}
