using Microsoft.EntityFrameworkCore;
using Task_MVC3.Models;

namespace Task_MVC3.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
        {
        }


        public DbSet<Products> Products { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
    }

}
