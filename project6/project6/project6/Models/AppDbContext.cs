using Microsoft.EntityFrameworkCore;

namespace project6.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<AdminLogin>AdminLogin { get; set; }
        public DbSet<slider> slider { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<product> product { get; set; }

        public DbSet<register> register { get; set; }

        public DbSet<SingleOrder> singleOrder { get; set; }



    }
}
