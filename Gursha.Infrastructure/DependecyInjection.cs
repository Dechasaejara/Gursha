using Gursha.Application.Common.Interfaces.Authentication;
// This Static class Inject Infrastructure Services to Api layer.

using Gursha.Application.Services.Authentication;
using Gursha.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Gursha.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IjwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}