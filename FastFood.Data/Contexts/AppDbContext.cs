using FastFood.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
namespace FastFood.Data.Contexts
{
public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }
        public DbSet<User> Users { get; set; }
}
}
