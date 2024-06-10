using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Modules.Patrons.Domain.Abstractions;
using DigitalLibrary.Modules.Patrons.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Patrons.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<PatronsDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPatronRepository, PatronRepository>();

        return services;
    }
}
