﻿using DigitalLibrary.Modules.Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Modules.Books.Persistence;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(BooksDbContext).Assembly);
    }

    public DbSet<Book> Books { get; set; }

    public DbSet<BookLend> BookLends { get; set; }

    public DbSet<Author> Authors { get; set; }
}
