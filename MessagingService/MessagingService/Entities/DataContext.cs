using Microsoft.EntityFrameworkCore;

namespace MessagingService.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<GroupMessage> GroupMessages { get; set; }
        public DbSet<GroupChat> GroupChats { get; set; }
        public DbSet<UserGroupChat> UserGroups { get; set; }


    }
}
