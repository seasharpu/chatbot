using Microsoft.EntityFrameworkCore;
namespace chatbotv1.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }
    }
}
