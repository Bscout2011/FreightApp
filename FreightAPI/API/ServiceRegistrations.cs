using FreightAPI.Features.Locations;

namespace FreightAPI.API;

public static class ServiceRegistrations
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddSingleton<ILocationService, LocationService>();
        return services;
    }
}
