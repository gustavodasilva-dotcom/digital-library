using System.Reflection;
using DigitalLibrary.Common.Infrastructure.MessageBroker;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DigitalLibrary.Common.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assemblies)
    {
        services.Configure<MessageBrokerSettings>(
            configuration.GetSection(MessageBrokerSettings.Position));

        services.AddSingleton(sp =>
            sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.AddConsumers(assemblies);

            busConfigurator.SetKebabCaseEndpointNameFormatter();

            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                MessageBrokerSettings settings = context
                    .GetRequiredService<MessageBrokerSettings>();

                configurator.Host(settings.Host, host =>
                {
                    host.Username(settings.Username);
                    host.Password(settings.Password);
                });

                configurator.ConfigureEndpoints(context);
            });
        });
    }
}
