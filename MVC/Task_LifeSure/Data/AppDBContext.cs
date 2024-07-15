using Microsoft.EntityFrameworkCore;
using Task_LifeSure.Models;

namespace Task_LifeSure.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<OurTeam> OurTeams { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }

    }
}
