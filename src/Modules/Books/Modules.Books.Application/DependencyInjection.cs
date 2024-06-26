﻿using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Books.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(AssemblyReference.Assembly));

        services.AddAutoMapper(AssemblyReference.Assembly);

        return services;
    }
}
