using DigitalLibrary.Modules.Patrons.Domain.Entities;
using DigitalLibrary.Modules.Patrons.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalLibrary.Modules.Patrons.Persistence.Configurations;

internal sealed class PatronLendConfiguration : IEntityTypeConfiguration<PatronLend>
{
    public void Configure(EntityTypeBuilder<PatronLend> builder)
    {
        builder.ToTable(DatabaseConstants.PatronLendsTable, tableBuilder =>
        {
            tableBuilder.HasCheckConstraint(
                DatabaseConstants.PatronLendsCheckNotEmptyGuid,
                sql: $"{nameof(PatronLend.LendId)} <> '{Guid.Empty}'");
        });

        builder.Property(p => p.Id);

        builder.HasIndex(p => new { p.PatronId, p.LendId })
            .IsUnique();
    }
}
