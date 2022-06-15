using Microsoft.EntityFrameworkCore;

namespace UserService.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        /*public DbSet<PersonalUser> PersonalUsers { get; set; }
        public DbSet<CorporateUser> CorporateUsers { get; set; }*/

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<PersonalUser>().ToTable("PersonalUsers");
            modelBuilder.Entity<CorporateUser>().ToTable("CorporateUsers");*/

            
                
        }
    }
}
