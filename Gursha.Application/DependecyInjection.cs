using Gursha.Application.Common.Interfaces.Authentication;
using Gursha.Application.Common.Interfaces.Persistence;
using Gursha.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;


namespace Gursha.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}