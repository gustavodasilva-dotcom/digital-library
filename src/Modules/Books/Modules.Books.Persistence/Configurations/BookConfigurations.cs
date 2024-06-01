using DigitalLibrary.Modules.Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Books.Persistence.Constants;

namespace DigitalLibrary.Modules.Books.Persistence.Configurations;

internal sealed class BookConfigurations : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable(DatabaseConstants.BooksTable, tableBuilder =>
        {
            tableBuilder.HasCheckConstraint(
                DatabaseConstants.BooksTableCheckNotNegative,
                sql: $"{nameof(Book.TotalPages)} > 0");
        });

        builder.HasKey(prop => prop.Id);

        builder.Property(prop => prop.Title).HasMaxLength(320);

        builder.Property(prop => prop.Isbn10).HasMaxLength(13);

        builder.Property(prop => prop.Isbn13).HasMaxLength(14);

        builder.HasMany(prop => prop.Lends)
            .WithOne()
            .HasForeignKey(lend => lend.BookId);
    }
}
