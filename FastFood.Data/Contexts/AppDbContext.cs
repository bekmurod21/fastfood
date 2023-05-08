using FastFood.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
namespace FastFood.Data.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
    
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { }
    public virtual DbSet<User> Users { get; set; }
}
