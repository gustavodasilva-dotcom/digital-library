using DigitalLibrary.Modules.Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Books.Persistence.Constants;

namespace DigitalLibrary.Modules.Books.Persistence.Configurations;

internal sealed class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable(DatabaseConstants.AuthorsTable);

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).HasMaxLength(200);

        builder.HasMany(p => p.Books)
            .WithOne()
            .HasForeignKey(b => b.AuthorId);
    }
}
