using BookWise.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookWise.Infra;
public static class InfraModule
{
    public static void AddInfraModule(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("CONN_POSTGRE_LOCALHOST_BOOK_WISE");

        services
            .AddDb(connectionString);
    }

    private static IServiceCollection AddDb(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<BookWiseDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }
}
