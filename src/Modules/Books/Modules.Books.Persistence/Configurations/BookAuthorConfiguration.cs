using DigitalLibrary.Modules.Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Books.Persistence.Constants;

namespace DigitalLibrary.Modules.Books.Persistence.Configurations;

internal sealed class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.ToTable(DatabaseConstants.BookAuthorsTable);

        builder.Property(p => p.Id);
    }
}
