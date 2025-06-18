using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FreightAPI.API.Endpoints;

public static class EndpointConfiguration
{
    /// <summary>
    /// Register all endpoints in the specified assembly.
    /// Source https://www.milanjovanovic.tech/blog/automatically-register-minimal-apis-in-aspnetcore
    /// </summary>
    [RequiresUnreferencedCode("")]
    public static IServiceCollection AddEndpoints(
        this IServiceCollection services,
        Assembly assembly
    )
    {
        ServiceDescriptor[] serviceDescriptors = assembly
            .DefinedTypes.Where(
                type =>
                    type is { IsAbstract: false, IsInterface: false }
                    && type.IsAssignableTo(typeof(IEndpoint))
            )
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .ToArray();
        services.TryAddEnumerable(serviceDescriptors);
        return services;
    }

    public static IApplicationBuilder MapEndpoints(
        this WebApplication app,
        RouteGroupBuilder? routerGroupBuilder = null
    )
    {
        IEnumerable<IEndpoint> endpoints = app.Services.GetRequiredService<
            IEnumerable<IEndpoint>
        >();
        IEndpointRouteBuilder builder = routerGroupBuilder is null ? app : routerGroupBuilder;
        foreach (IEndpoint endpoint in endpoints)
        {
            endpoint.MapEndpoint(builder);
        }
        return app;
    }
}
