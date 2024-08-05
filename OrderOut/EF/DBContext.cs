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
            public virtual DbSet<TableWaiter> TablesWaiters { get; set; }
            public virtual DbSet<Bill> Bills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            // Relación uno a muchos entre Category y Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category);

            // Relación uno a muchos entre Menu y Product
            modelBuilder.Entity<Menu>()
                .HasMany(m => m.Products);

            modelBuilder.Entity<UserRole>()
                 .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u=> u.UsersRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany()
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Table)
                .WithMany()
                .HasForeignKey(o => o.TableId);

            // Configuración de la relación entre Order y User
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithOne()
                .HasForeignKey(op => op.OrderId);

            // Relación uno a muchos entre Product y OrderProduct
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product);

        }
    }
}