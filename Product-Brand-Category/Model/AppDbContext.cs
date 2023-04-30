
using Microsoft.EntityFrameworkCore;

namespace Product_Brand_Category.Model

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; } 
        public DbSet<Category> Categories { get; set; }
    }
}
