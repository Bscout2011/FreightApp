using FreightAPI.API.Endpoints;
using FreightAPI.Domain.Shipments;
using Marten;

namespace FreightAPI.API.Shipments;

public class GetShipment : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
            "shipments/{id:guid}",
            async (Guid id, IQuerySession session) =>
            {
                var shipment = await session.LoadAsync<Shipment>(id);

                return shipment is not null ? Results.Ok(shipment) : Results.NotFound();
            }
        );
    }
}
