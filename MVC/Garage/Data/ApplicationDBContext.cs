using Garage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Garage.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected ApplicationDBContext()
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Settings> Settings { get; set; }
    }
}
