using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Common.Infrastructure.Installers;

public static class DependencyInstaller
{
    public static IServiceCollection InstallDependencies(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assemblies)
    {
        static bool IsAssignableToType<T>(TypeInfo typeInfo) =>
            typeof(T).IsAssignableFrom(typeInfo) &&
            !typeInfo.IsInterface &&
            !typeInfo.IsAbstract;

        var serviceInstallers = assemblies
            .SelectMany(a => a.DefinedTypes)
            .Where(IsAssignableToType<IDependencyInstaller>)
            .Select(Activator.CreateInstance)
            .Cast<IDependencyInstaller>()
            .ToList();

        serviceInstallers.ForEach(
            si => si.InstallService(
                services,
                configuration));

        return services;
    }
}
