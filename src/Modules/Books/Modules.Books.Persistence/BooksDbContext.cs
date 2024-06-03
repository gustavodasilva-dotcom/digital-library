using DigitalLibrary.Modules.Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Modules.Books.Persistence.Constants;

namespace DigitalLibrary.Modules.Books.Persistence;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DatabaseConstants.Schema);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(BooksDbContext).Assembly);
    }

    public DbSet<Book> Books { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<BookAuthor> BookAuthors { get; set; }
    
    public DbSet<BookLend> BookLends { get; set; }
}
