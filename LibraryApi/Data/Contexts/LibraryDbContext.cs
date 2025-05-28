using LibraryApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data
{


    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FavoriteBook> FavoriteBooks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
