using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }

        public ApplicationDBContext(DbSet<Products> products, DbSet<Category> categories)
        {
            Products = products;
            Categories = categories;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
