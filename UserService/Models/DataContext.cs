using Microsoft.EntityFrameworkCore;

namespace UserService.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserModel> users { get; set; }        

    }
}
