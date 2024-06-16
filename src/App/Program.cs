using DigitalLibrary.App.Middlewares;
using DigitalLibrary.Common.Infrastructure.Installers;
using DigitalLibrary.Common.Infrastructure.MessageBroker;
using MassTransit;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .InstallDependencies(
        builder.Configuration,
        DigitalLibrary.Modules.Books.Infrastructure.AssemblyReference.Assembly,
        DigitalLibrary.Modules.Lendings.Infrastructure.AssemblyReference.Assembly,
        DigitalLibrary.Modules.Patrons.Infrastructure.AssemblyReference.Assembly);

builder.Services.Configure<MessageBrokerSettings>(
    builder.Configuration.GetSection(MessageBrokerSettings.Position));

builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.AddConsumers(
        DigitalLibrary.Modules.Books.Application.AssemblyReference.Assembly,
        DigitalLibrary.Modules.Patrons.Application.AssemblyReference.Assembly);

    busConfigurator.SetKebabCaseEndpointNameFormatter();
    
    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        MessageBrokerSettings settings = context.GetRequiredService<MessageBrokerSettings>();

        configurator.Host(settings.Host, host =>
        {
            host.Username(settings.Username);
            host.Password(settings.Password);
        });

        configurator.ConfigureEndpoints(context);
    });
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();
