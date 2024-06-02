using DigitalLibrary.Modules.Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Books.Persistence.Constants;

namespace DigitalLibrary.Modules.Books.Persistence.Configurations;

internal sealed class BookLendConfiguration : IEntityTypeConfiguration<BookLend>
{
    public void Configure(EntityTypeBuilder<BookLend> builder)
    {
        builder.ToTable(DatabaseConstants.BookLendsTable);

        builder.Property(prop => prop.Id);
    }
}
