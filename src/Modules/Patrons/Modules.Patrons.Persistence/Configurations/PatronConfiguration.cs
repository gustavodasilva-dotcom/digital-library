using DigitalLibrary.Modules.Patrons.Domain.Entities;
using DigitalLibrary.Modules.Patrons.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalLibrary.Modules.Patrons.Persistence.Configurations;

internal sealed class PatronConfiguration : IEntityTypeConfiguration<Patron>
{
    public void Configure(EntityTypeBuilder<Patron> builder)
    {
        builder.ToTable(DatabaseConstants.PatronsTable);

        builder.HasKey(p => p.Id);

        builder.HasIndex(p => p.RegistrationNumber).IsUnique();

        builder.Property(p => p.FirstName).HasMaxLength(50);

        builder.Property(p => p.MiddleName)
            .HasMaxLength(50)
            .IsRequired(false);

        builder.Property(p => p.LastName).HasMaxLength(50);
    }
}
