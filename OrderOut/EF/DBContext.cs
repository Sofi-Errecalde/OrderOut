using Microsoft.EntityFrameworkCore;
using OrderOut.EF.Models;
namespace DBContext
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            { }

            public virtual DbSet<Product> Products { get; set; }
            public virtual DbSet<Menu> Menus { get; set; }
            public virtual DbSet<Category> Categories { get; set; }
            public virtual DbSet<User> Users { get; set; }
            public virtual DbSet<UserRole> UsersRoles { get; set; }
            public virtual DbSet<Role> Roles { get; set; }
            public virtual DbSet<Table> Tables { get; set; }
            public virtual DbSet<Order> Orders { get; set; }
            public virtual DbSet<OrderProduct> OrderProducts { get; set; }
            public virtual DbSet<Waiter> Waiters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            // Relación uno a muchos entre Category y Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category);

            // Relación uno a muchos entre Menu y Product
            modelBuilder.Entity<Menu>()
                .HasMany(m => m.Products);

            // Relación uno a muchos entre User y UserRole
            // Relación uno a muchos entre User y UserRole
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User);

            // Relación uno a muchos entre Role y UserRole
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role);

            // Relación uno a muchos entre Table y Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Table)
                .WithMany(t => t.Orders);


            // Relación uno a muchos entre Order y OrderProduct
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order);

            // Relación uno a muchos entre Product y OrderProduct
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product);

        }
    }
}