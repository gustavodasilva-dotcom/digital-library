using DigitalLibrary.Modules.Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Books.Persistence.Constants;

namespace DigitalLibrary.Modules.Books.Persistence.Configurations;

internal sealed class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.ToTable(DatabaseConstants.PublishersTable);

        builder.Property(p => p.Id);

        builder.Property(p => p.Name).HasMaxLength(200);

        builder.HasIndex(p => p.Name).IsUnique();

        builder.HasMany(p => p.Books)
            .WithOne(b => b.Publisher)
            .HasForeignKey(b => b.PublisherId);
    }
}
