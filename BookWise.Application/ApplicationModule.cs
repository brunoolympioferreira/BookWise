using BookWise.Application.Services.Auth;
using BookWise.Application.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace BookWise.Application;
public static class ApplicationModule
{
    public static void AddApplicationModule(this IServiceCollection services)
    {
        services.AddServices();
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserService, UserService>()
            .AddScoped<IAuthService, AuthService>();
    }
}
