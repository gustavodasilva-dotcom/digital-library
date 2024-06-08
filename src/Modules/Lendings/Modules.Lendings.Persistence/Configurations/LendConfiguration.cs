using DigitalLibrary.Modules.Lendings.Domain.Entities;
using DigitalLibrary.Modules.Lendings.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalLibrary.Modules.Lendings.Persistence.Configurations;

internal sealed class LendConfiguration : IEntityTypeConfiguration<Lend>
{
    public void Configure(EntityTypeBuilder<Lend> builder)
    {
        builder.ToTable(DatabaseConstants.LendsTable);

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Code).HasMaxLength(10);

        builder.HasIndex(p => p.Code).IsUnique();
    }
}
