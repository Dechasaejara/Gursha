using Gursha.Application.Common.Interfaces.Authentication;
using Gursha.Application.Common.Interfaces.Persistence;
// This Static class Inject Infrastructure Services to Api layer.

using Gursha.Application.Services.Authentication;
using Gursha.Infrastructure.Authentication;
using Gursha.Infrastructure.Persistence;
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

        services.AddScoped<IUserRespository, UserRespository>();
        return services;
    }
}