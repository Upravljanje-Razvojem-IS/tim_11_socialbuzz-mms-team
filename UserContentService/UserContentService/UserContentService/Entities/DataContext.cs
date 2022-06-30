using Microsoft.EntityFrameworkCore;

namespace UserContentService.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Ad> Ads { get; set; }
    }
}
