using FreightAPI.API.Endpoints;
using FreightAPI.Domain.Loads;
using Marten;

namespace FreightAPI.API.Loads;

public class GetLoad : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
            "loads/{id:guid}",
            async (Guid id, IQuerySession session) =>
            {
                var shipment = await session.LoadAsync<Load>(id);

                return shipment is not null ? Results.Ok(shipment) : Results.NotFound();
            }
        );
    }
}
