using FreightAPI.API.Endpoints;
using FreightApp.Domain.Loads;
using Marten;

namespace FreightAPI.API.Loads;

public class ListLoads : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/loads",
            async (IQuerySession session, CancellationToken cancellationToken) =>
            {
                var loads = await session.Query<Load>().ToListAsync(cancellationToken);
                return Results.Ok(loads);
            }
        );
    }
}
