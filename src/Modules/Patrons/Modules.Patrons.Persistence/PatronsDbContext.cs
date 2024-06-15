using DigitalLibrary.Modules.Patrons.Domain.Entities;
using DigitalLibrary.Modules.Patrons.Persistence.Constants;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Modules.Patrons.Persistence;

public class PatronsDbContext : DbContext
{
    public PatronsDbContext(DbContextOptions<PatronsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DatabaseConstants.Schema);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(PatronsDbContext).Assembly);
    }

    public DbSet<Patron> Patrons { get; set; }

    public DbSet<PatronLend> PatronLends { get; set; }
}
