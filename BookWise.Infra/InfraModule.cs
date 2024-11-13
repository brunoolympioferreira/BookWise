using BookWise.Core.Repositories;
using BookWise.Infra.GoogleBook;
using BookWise.Infra.Persistence;
using BookWise.Infra.Persistence.Repositories;
using BookWise.Infra.Persistence.UnityOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookWise.Infra;
public static class InfraModule
{
    public static void AddInfraModule(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("CONN_POSTGRE_LOCALHOST_BOOK_WISE");

        services
            .AddDb(connectionString)
            .AddRepositories()
            .AddUnityOfWork()
            .AddClients();
    }

    private static IServiceCollection AddDb(this IServiceCollection services, string? connectionString)
    {
        return services.AddDbContext<BookWiseDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IBookRepository, BookRepository>()
            .AddScoped<IReviewRepository, ReviewRepository>();
    }

    private static IServiceCollection AddUnityOfWork(this IServiceCollection services) 
    {
        return services
            .AddScoped<IUnityOfWork, UnityOfWork>();
    }

    public static IServiceCollection AddClients(this IServiceCollection services)
    {
        return services
            .AddScoped<IGoogleBookClient, GoogleBookClient>();
    }
}
