using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using FastFood.Domain.Entities.Users;
using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Entities.Payment;
using FastFood.Domain.Entities.Products;

namespace FastFood.Data.Contexts;
public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
    
    }
    
    
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Cart> Carts { get; set; }
    public virtual DbSet<Order> Orderes { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<Address> Addresses { get;set; }
    public virtual DbSet<Product> Products { get; set; }
   /// public virtual DbSet<Attachment> Attachments { get; set; }
}
