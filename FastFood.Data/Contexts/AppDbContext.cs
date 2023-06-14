using Microsoft.EntityFrameworkCore;
using FastFood.Domain.Entities.Users;
using FastFood.Domain.Entities.Products;

namespace FastFood.Data.Contexts;
public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
    
    }
   

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Product> Products { get; set; }
}
