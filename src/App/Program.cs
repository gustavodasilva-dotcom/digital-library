using DigitalLibrary.App.Middlewares;
using DigitalLibrary.Common.Infrastructure.Endpoints;
using DigitalLibrary.Modules.Books.Infrastructure;
using DigitalLibrary.Modules.Lendings.Infrastructure;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLending(builder.Configuration);
builder.Services.AddBooks(builder.Configuration);

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

app.MapRegisteredEndpoints();

app.Run();
