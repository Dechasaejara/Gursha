using Gursha.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;


namespace Gursha.Infrastructure;

public static class DependecyInjection
{    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}