using BookWise.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookWise.Infra.Persistence;
public class BookWiseDbContext : DbContext
{
    public BookWiseDbContext(DbContextOptions<BookWiseDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
