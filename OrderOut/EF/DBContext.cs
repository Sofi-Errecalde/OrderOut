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
        public virtual DbSet<Product> Categorys { get; set; }

    
    }
}