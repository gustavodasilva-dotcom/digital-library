using DigitalLibrary.Modules.Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Books.Persistence.Constants;

namespace DigitalLibrary.Modules.Books.Persistence.Configurations;

internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable(DatabaseConstants.BooksTable, tableBuilder =>
        {
            tableBuilder.HasCheckConstraint(
                DatabaseConstants.BooksTableCheckNotNegative,
                sql: $"{nameof(Book.TotalPages)} > 0");
        });

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Title).HasMaxLength(320);

        builder.Property(p => p.Edition).HasMaxLength(50);

        builder.Property(p => p.Isbn10).HasMaxLength(13);

        builder.Property(p => p.Isbn13).HasMaxLength(14);

        builder.HasMany(p => p.Lends)
            .WithOne()
            .HasForeignKey(l => l.BookId);

        builder.HasMany(p => p.Authors)
            .WithOne()
            .HasForeignKey(a => a.BookId);
    }
}
