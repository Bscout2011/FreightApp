using FreightAPI.API.Endpoints;
using FreightAPI.Domain.Shipments;
using Marten;

namespace FreightAPI.API.Shipments;

public record CreateShipmentRequest(string Origin, string Destination, DateTime ScheduledAt);

public class CreateShipment : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "shipments",
            async (CreateShipmentRequest request, IDocumentStore store) =>
            {
                await using var session = store.LightweightSession();
                var shipment = new Shipment()
                {
                    Origin = request.Origin,
                    Destination = request.Destination,
                    ScheduledAt = request.ScheduledAt,
                };

                session.Store(shipment);
                await session.SaveChangesAsync();
                return Results.Created($"/shipments/{shipment.Id}", shipment);
            }
        );
    }
}
