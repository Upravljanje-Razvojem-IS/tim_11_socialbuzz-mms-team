using Microsoft.EntityFrameworkCore;

namespace ProductsAndServices.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<ServiceType> ServiceTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProductType>().ToTable("ProductTypes");
            //modelBuilder.Entity<ServiceType>().ToTable("ServiceTypes");

            modelBuilder.Entity<ProductType>().HasIndex(p => p.Description).IsUnique();

            modelBuilder.Entity<ServiceType>().HasIndex(p => p.Description).IsUnique();
        }
    }
}
