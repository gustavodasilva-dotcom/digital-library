using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Constants;
using DigitalLibrary.Modules.Books.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary.Modules.Books.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BooksDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

        services
            .AddKeyedScoped<IUnitOfWork, UnitOfWork>(ServicesConstants.BooksUnitOfWork)
            .AddScoped<IBookRepository, BookRepository>()
            .AddScoped<IAuthorRepository, AuthorRepository>()
            .AddScoped<IBookAuthorRepository, BookAuthorRepository>()
            .AddScoped<IBookLendRepository, BookLendRepository>()
            .AddScoped<IPublisherRepository, PublisherRepository>();

        return services;
    }
}
