using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using FastFood.Domain.Entities.Users;
using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Entities.Payment;
using FastFood.Domain.Entities.Products;
using FastFood.Domain.Entities.Authorizations;

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
    public virtual DbSet<Permission> Permissions { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<RolePermission> RolePermissions { get; set; }
    public virtual DbSet<CartItem> CartItems { get; set; }
    public virtual DbSet<OrderItem> OrderItems { get;set; }
    public virtual DbSet<OrderProduct> OrderProducts { get; set; }
    public virtual DbSet<Attachment> Attachments { get; set; }
}
