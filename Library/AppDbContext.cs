
using Library.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author>Authors { get; set; }
        public DbSet<Book>Books { get; set; }
        public DbSet<Genere>Generes { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasMany(x=>x.Author).WithMany(x=> x.Books);
            modelBuilder.Entity<Book>().HasMany(x=>x.Generes).WithMany(x=> x.Books);
        }
    }
}
