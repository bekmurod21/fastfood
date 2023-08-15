using System.Text;
using Microsoft.OpenApi.Models;
using FastFood.Data.Repositories;
using FastFood.Data.IRepositories;
using Microsoft.IdentityModel.Tokens;
using FastFood.Service.Services.Users;
using FastFood.Service.Services.Orders;
using FastFood.Service.Interfaces.Order;
using FastFood.Service.Interfaces.Users;
using FastFood.Service.Interfaces.Orders;
using FastFood.Service.Services.Products;
using FastFood.Service.Services.Addresses;
using FastFood.Service.Interfaces.Products;
using FastFood.Service.Interfaces.Addresses;
using FastFood.Service.Services.Attachments;
using FastFood.Service.Interfaces.Attachments;
using FastFood.Service.Services.Authorizations;
using FastFood.Service.Interfaces.Authorizations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FastFood.Service.Services.Feedbacks;

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
            services.AddScoped<IEmailService,EmailService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAttachmentService, AttachmentService>();
            services.AddScoped<IAddressService, AddressService>();

            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();
            services.AddScoped<IRoleService,RoleService>();
            
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderActionService, OrderActionService>();
            services.AddScoped<IOrderService, OrderService>();
            
            services.AddScoped<IFeedbackAdminService,FeedbackAdminService>();
            services.AddScoped<IFeedbackService, FeedbackService>();

            services.AddScoped<IPaymentService, PaymentService>();
            
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductService, ProductService>();
        }
        /// <summary>
        /// Add services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddJwtService(this  IServiceCollection services,IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
        /// <summary>
        /// Configure swagger generation and auth buttons
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
            });
        }
    }
}
