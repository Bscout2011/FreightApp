using FreightAPI.API.Endpoints;
using FreightAPI.Domain.Shipments;
using Marten;

namespace FreightAPI.API.Shipments;

public class CreateShipment : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "shipments",
            async (IDocumentStore store) =>
            {
                await using var session = store.LightweightSession();
                var shipment = new Shipment()
                {
                    Id = Guid.NewGuid(),
                    Origin = "New York",
                    Destination = "Los Angeles",
                    ScheduledAt = DateTime.UtcNow.AddDays(5)
                };

                session.Store(shipment);
                await session.SaveChangesAsync();
                return Results.Created($"/shipments/{shipment.Id}", shipment);
            }
        );
    }
}
