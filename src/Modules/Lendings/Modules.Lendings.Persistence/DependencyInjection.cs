using DigitalLibrary.Modules.Lendings.Domain.Abstractions;
using DigitalLibrary.Modules.Lendings.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Lendings.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<LendingDbContext>(options =>
            options.UseInMemoryDatabase("database"));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ILendRepository, LendRepository>();

        return services;
    }
}
