using BookWise.Core.Repositories;
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
            .AddUnityOfWork();
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
            .AddScoped<IUserRepository, UserRepository>();
    }

    private static IServiceCollection AddUnityOfWork(this IServiceCollection services) 
    {
        return services
            .AddScoped<IUnityOfWork, UnityOfWork>();
    }
}
