using DigitalLibrary.App.Middlewares;
using DigitalLibrary.Common.Infrastructure.Installers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .InstallDependencies(
        builder.Configuration,
        DigitalLibrary.Modules.Books.Infrastructure.AssemblyReference.Assembly,
        DigitalLibrary.Modules.Lendings.Infrastructure.AssemblyReference.Assembly,
        DigitalLibrary.Modules.Patrons.Infrastructure.AssemblyReference.Assembly);

builder.Services.AddMassTransit(config =>
{
    config.AddConsumers(
        DigitalLibrary.Modules.Books.Application.AssemblyReference.Assembly);
    
    config.UsingInMemory((context, config) =>
    {
        config.ConfigureEndpoints(context);
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
