using FastFood.Domain.Enums;
using FastFood.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using FastFood.Domain.Entities.Users;
using FastFood.Domain.Entities.Orders;
using FastFood.Domain.Entities.Payments;
using FastFood.Domain.Entities.Products;
using FastFood.Domain.Entities.Attachments;
using FastFood.Domain.Entities.Authorizations;
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

        //modelBuilder.Entity<Order>()
        //        .HasOne(o => o.Address)
        //        .WithMany()
        //        .HasForeignKey(o => o.AddressId)
        //        .OnDelete(DeleteBehavior.NoAction);

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
               new Role() { Id = 3, Name = "Driver", CreatedAt = DateTime.UtcNow, IsDeleted = false, UpdatedBy = null, DeletedBy = null, UpdatedAt = null },
               new Role() { Id = 4, Name = "Picker", CreatedAt = DateTime.UtcNow, IsDeleted = false, UpdatedBy = null, DeletedBy = null, UpdatedAt = null },
               new Role() { Id = 5, Name = "Packer", CreatedAt = DateTime.UtcNow, IsDeleted = false, UpdatedBy = null, DeletedBy = null, UpdatedAt = null }
               );
        modelBuilder.Entity<User>().HasData(
            new User() { Id = 1, FirstName = "Mukhammadkarim", LastName = "Tukhtaboyev",UserName = "Mukhammadkarim" ,Email = "dotnetgo@icloud.com", Phone = "+998 991239999", RoleId = 2, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null, Gender = Gender.Male },
            new User() { Id = 2, FirstName = "Jamshid", LastName = "Ma'ruf",UserName = "Jamshid" ,Email = "wonderboy1w3@gmail.com", Phone = "+998 991231999", RoleId = 3, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null, Gender = Gender.Male },
            new User() { Id = 3, FirstName = "Kabeer", LastName = "Solutions", UserName = "Kabeer", Email = "kabeersolutions@gmail.com", Phone = "+998 991232999", RoleId = 4, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null, Gender = Gender.Male },
            new User() { Id = 4, FirstName = "Muzaffar", LastName = "Nurillayev", UserName = "Muzaffar", Email = "nurillaewmuzaffar@gmail.com", Phone = "+998 995030110", RoleId = 5, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null, Gender = Gender.Male },
            new User() { Id = 5, FirstName = "Azim", LastName = "Ochilov", UserName = "Azim", Email = "azimochilov@icloud.com", Phone = "+998 991233999", RoleId = 1, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null, Gender = Gender.Male },
            new User() { Id = 6, FirstName = "Abdulloh", LastName = "Ahmadjonov",   UserName = "Abdulloh", Email = "abdulloh@icloud.com", Phone = "+998 991236999", RoleId = 1, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null, Gender = Gender.Male },
            new User() { Id = 7, FirstName = "Komron", LastName = "Rahmonov", UserName = "Komron", Email = "komron2052@gmail.com", Phone = "+998 991234999", RoleId = 4, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null, Gender = Gender.Male },
            new User() { Id = 8, FirstName = "Nozimjon", LastName = "Usmonaliyev", UserName = "Nozimjon", Email = "nozimjon@gmail.com", Phone = "+998 991235999", RoleId = 1, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null , Gender = Gender.Male },
            new User() { Id = 9, FirstName = "AlJavhar", LastName = "Boyaliyev", UserName = "AlJavhar", Email = "aljavhar@gmail.com", Phone = "+998 902344545", RoleId = 4, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null , Gender = Gender.Male },
            new User() { Id = 10, FirstName = "Muhammad", LastName = "Rahimboyev", UserName = "Muhammad",Email = "muhammad@gmail.com", Phone = "+998 937770202", RoleId = 5, Password = PasswordHelper.Hash("12345678"), CreatedAt = DateTime.UtcNow, UpdatedAt = null , Gender = Gender.Male },
            new User() { Id = 11, FirstName = "Bekmurod", LastName = "Boqiyev",UserName = "Bekmurodt" ,Email = "boqiyev482@gmail.com", Phone = "998 90 848 05 210", Gender = Gender.Male, CreatedAt = DateTime.UtcNow, IsDeleted = false, Password = PasswordHelper.Hash("Bekmurod21"), RoleId = 2 }
            );
        modelBuilder.Entity<Cart>().HasData(
            new Cart() { Id = 1, UserId = 1, Items = null },
            new Cart() { Id = 2, UserId = 2, Items = null },
            new Cart() { Id = 3, UserId = 3, Items = null },
            new Cart() { Id = 4, UserId = 4, Items = null },
            new Cart() { Id = 5, UserId = 5, Items = null },
            new Cart() { Id = 6, UserId = 6, Items = null },
            new Cart() { Id = 7, UserId = 7, Items = null },
            new Cart() { Id = 8, UserId = 8, Items = null },
            new Cart() { Id = 9, UserId = 9, Items = null },
            new Cart() { Id = 10, UserId = 10, Items = null },
            new Cart() { Id = 11, UserId = 11, Items = null }
            );

        modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory() { Id = 1, Name = "APPETIZERS", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
                new ProductCategory() { Id = 2, Name = "Burgers", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
                new ProductCategory() { Id = 3, Name = "Chicken", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
                new ProductCategory() { Id = 4, Name = "Desserts", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
                new ProductCategory() { Id = 5, Name = "Drinks", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
                new ProductCategory() { Id = 6, Name = "Kids Meal", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
                new ProductCategory() { Id = 7, Name = "Pizza", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
                new ProductCategory() { Id = 8, Name = "Spinner", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
                new ProductCategory() { Id = 9, Name = "Salad & other", CreatedAt = DateTime.UtcNow, UpdatedAt = null },
                new ProductCategory() { Id =10,Name = "Combo",CreatedAt = DateTime.UtcNow,UpdatedAt = null}
                );
        modelBuilder.Entity<Product>().HasData(
            new Product() { Id = 1, Name = "Beef Longer", Description = "Best Food", Price = 26000, Weight = 180, CategoryId = 2, CreatedAt = DateTime.UtcNow, IsDeleted = false },
            new Product() { Id = 2, Name = "Bigger", Description = "Bigger burger", Price = 25000, Weight = 200, CategoryId = 2, CreatedAt = DateTime.UtcNow, IsDeleted = false },
            new Product() { Id = 3, Name = "CHEESE BURGER", Description = "Cheese burger", Price = 29000, Weight = 190, CategoryId = 2, CreatedAt = DateTime.UtcNow, IsDeleted = false },
            new Product() { Id = 4, Name = "CHICKY BURGER", Description = "CHICKY BURGER", Price = 18000, Weight = 150, CategoryId = 2, CreatedAt = DateTime.UtcNow, IsDeleted = false },
            new Product() { Id = 5, Name = "CHICKY BURGER SET", Description = "chicky burger,cola,soup,free", Price = 36000, Weight = 300, CategoryId = 2, CreatedAt = DateTime.UtcNow, IsDeleted = false },
            new Product() { Id = 6, Name = "CHILI LONGER", Description = "long burger", Price = 26000, Weight = 190, CategoryId = 2, CreatedAt = DateTime.UtcNow, IsDeleted = false },
            new Product() { Id = 7, Name = "CLASSIC", Description = "Simple burger", Price = 19000, Weight = 180, CategoryId = 2, CreatedAt = DateTime.UtcNow, IsDeleted = false },
            new Product() { Id = 8, Name = "DOUBLE CHEESE BURGER", Description = "double burger", Price = 44000, Weight = 360, CategoryId = 2, CreatedAt = DateTime.UtcNow, IsDeleted = false },
            new Product() { Id = 9, Name = "HAMBURGER", Description = "HAMBURGER", Price = 26000, Weight = 190, CategoryId = 2, CreatedAt = DateTime.UtcNow, IsDeleted = false },
            new Product() { Id = 10, Name = "JUNIOR BURGER", Description = "short burger", Price = 18000, Weight = 150, CategoryId = 2, CreatedAt = DateTime.UtcNow, IsDeleted = false },
            new Product() { Id = 11, Name = "JUNIOR BURGER SET", Description = "junior burger,cola,KFC,free", Price = 33000, Weight = 300, CategoryId = 2, CreatedAt = DateTime.UtcNow, IsDeleted = false },
            new Product() { Id = 12, Name = "Longer", Description = "long burger", Price = 22000, Weight = 220, CategoryId = 2, CreatedAt = DateTime.UtcNow, IsDeleted = false },
            new Product() { Id = 13, Name= "ROAST BURGER",Description ="tasty burger",Price=27000,Weight=200,CategoryId = 2, CreatedAt = DateTime.UtcNow,IsDeleted = false }
            );
        #endregion

    }
}
