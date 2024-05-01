using Microsoft.EntityFrameworkCore;
using chatbotv1.Models;

namespace chatbotv1.Data
{
    public class MyDBContext : DbContext
    {

        public DbSet<Firebase> Firebase { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserQuery> UserQueries { get; set; }
        public DbSet<History> Conversations { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasData(new User() {
                Id = 1,
                UserName = "OpenAI",
                Password = "SuperSecretPassword",
                lastActivity = DateTime.Now
            });
        }
    }
}
