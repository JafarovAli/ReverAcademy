using Microsoft.EntityFrameworkCore;
using Task_MVC.Models;

namespace Task_MVC.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Shop> Shop { get; set; }


    }
}
