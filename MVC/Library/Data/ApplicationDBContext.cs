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

        public ApplicationDBContext(DbSet<Books> books, DbSet<Author> authors, DbSet<Libraries> libraries)
        {
            Books = books;
            Authors = authors;
            Libraries = libraries;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Libraries> Libraries { get; set; }


    }
}
