using Serilog;
using FastFood.WebApi.Models;
using FastFood.Data.Contexts;
using FastFood.Domain.Helpers;
using FastFood.Service.Mappers;
using FastFood.WebApi.Extensions;
using FastFood.WebApi.Middlewares;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("FastFood.Data")));

builder.Services.AddCustomService();
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddJwtService(builder.Configuration);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administration", p => p.RequireRole("Admin", "SuperAdmin"));
    options.AddPolicy("AdminMerchant", p => p.RequireRole("Admin", "Merchant"));
    options.AddPolicy("Worker", p => p.RequireRole("Driver", "Picker", "Packer"));
});

// Convert Api Url name to dashcase
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(
                                        new ConfigureApiUrlName()));
});
builder.Services.AddControllersWithViews()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


//Logger
var logger = new LoggerConfiguration()
    .ReadFrom
    .Configuration(builder.Configuration)
    .Enrich
    .FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var app = builder.Build();
app.ApplyMigration();
app.InitAccessor();

// Getting wwwroot path
EnvironmentHelper.WebRootPath = Path.GetFullPath("wwwroot");



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
