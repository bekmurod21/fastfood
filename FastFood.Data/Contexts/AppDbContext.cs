using FastFood.Domain.Entities.Commons;
using FastFood.Domain.Entities.Products;
using FastFood.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
namespace FastFood.Data.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
    
    }
    
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Attachment> Attachments { get; set; }
}
