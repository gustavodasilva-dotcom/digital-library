using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Modules.Lendings.Domain.Abstractions;
using DigitalLibrary.Modules.Lendings.Domain.Constants;
using DigitalLibrary.Modules.Lendings.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Lendings.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<LendingsDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

        services
            .AddKeyedScoped<IUnitOfWork, UnitOfWork>(ServicesConstants.LendingsUnitOfWork)
            .AddScoped<ILendRepository, LendRepository>();

        return services;
    }
}
