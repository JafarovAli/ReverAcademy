using Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
        }


        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }
        public ApplicationDBContext(DbSet<Car> cars, DbSet<ContactUs> contactUs)
        {
            Cars = cars;
            ContactUs = contactUs;
        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Car;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
