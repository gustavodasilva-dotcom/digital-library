using DigitalLibrary.App.Middlewares;
using DigitalLibrary.Common.Infrastructure.Installers;
using DigitalLibrary.Common.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .InstallDependencies(
        builder.Configuration,
        DigitalLibrary.Modules.Books.Infrastructure.AssemblyReference.Assembly,
        DigitalLibrary.Modules.Lendings.Infrastructure.AssemblyReference.Assembly,
        DigitalLibrary.Modules.Patrons.Infrastructure.AssemblyReference.Assembly);

builder.Services
    .AddInfrastructure(
        builder.Configuration,
        DigitalLibrary.Modules.Books.Infrastructure.AssemblyReference.Assembly,
        DigitalLibrary.Modules.Patrons.Infrastructure.AssemblyReference.Assembly);

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
