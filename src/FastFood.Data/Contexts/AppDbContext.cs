using Microsoft.EntityFrameworkCore;
using FastFood.Domain.Entities.Users;
using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Entities.Payments;
using FastFood.Domain.Entities.Products;
using FastFood.Domain.Entities.Authorizations;
using FastFood.Domain.Entities.Attachments;
using FastFood.Domain.Entities.Orders.Feedbacks;

namespace FastFood.Data.Contexts;
public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
    
    }

    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Cart> Carts { get; set; }
    public virtual DbSet<Order> Orderes { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<Address> Addresses { get;set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<CartItem> CartItems { get; set; }
    public virtual DbSet<Feedback> Feedbacks { get; set; }
    public virtual DbSet<OrderItem> OrderItems { get;set; }
    public virtual DbSet<Permission> Permissions { get; set; }
    public virtual DbSet<Attachment> Attachments { get; set; }
    public virtual DbSet<OrderProduct> OrderProducts { get; set; }
    public virtual DbSet<RolePermission> RolePermissions { get; set; }
    public virtual DbSet<FeedbackAttachment> FeedbackAttachments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Fluent Api realitions
        modelBuilder.Entity<Payment>()
            .HasOne(payment => payment.User)
            .WithMany(user => user.Payments)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
            .HasOne(order => order.User)
            .WithMany(user => user.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
                .HasOne(o => o.Address)
                .WithMany()
                .HasForeignKey(o => o.AddressId)
                .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Payments)
            .WithOne(p => p.Order)
            .HasForeignKey<Order>(o => o.PaymentId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<OrderItem>()
            .HasOne(item => item.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(item => item.OrderId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<OrderItem>()
            .HasOne(item => item.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(item => item.ProductId)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Product>()
               .HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<OrderAction>()
            .HasOne(action => action.Order)
            .WithMany(order => order.OrderActions)
            .HasForeignKey(action => action.OrderId)
            .OnDelete(DeleteBehavior.NoAction);
        #endregion

        #region Seed data
        modelBuilder.Entity<Role>().HasData(
               new Role() { Id = 1, Name = "User", CreatedAt = DateTime.UtcNow, IsDeleted = false, UpdatedBy = null, DeletedBy = null, UpdatedAt = null },
               new Role() { Id = 2, Name = "Admin", CreatedAt = DateTime.UtcNow, IsDeleted = false, UpdatedBy = null, DeletedBy = null, UpdatedAt = null },
               new Role() { Id = 3, Name = "Merchant", CreatedAt = DateTime.UtcNow, IsDeleted = false, UpdatedBy = null, DeletedBy = null, UpdatedAt = null },
               new Role() { Id = 4, Name = "Driver", CreatedAt = DateTime.UtcNow, IsDeleted = false, UpdatedBy = null, DeletedBy = null, UpdatedAt = null },
               new Role() { Id = 5, Name = "Picker", CreatedAt = DateTime.UtcNow, IsDeleted = false, UpdatedBy = null, DeletedBy = null, UpdatedAt = null },
               new Role() { Id = 6, Name = "Packer", CreatedAt = DateTime.UtcNow, IsDeleted = false, UpdatedBy = null, DeletedBy = null, UpdatedAt = null }
               );

        #endregion

    }
}
