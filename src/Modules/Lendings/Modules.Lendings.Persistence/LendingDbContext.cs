using DigitalLibrary.Modules.Lendings.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Modules.Lendings.Persistence;

public class LendingDbContext : DbContext
{
    private readonly IPublisher _publisher;

    public LendingDbContext(
        DbContextOptions<LendingDbContext> options,
        IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }

    private async Task PublishDomainEventsAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity => entity.GetDomainEvents())
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }
    }

    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        await PublishDomainEventsAsync();

        return result;
    }

    public DbSet<Lend> Lends { get; set; }
}
