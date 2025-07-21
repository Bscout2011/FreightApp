using FreightAPI.API.Endpoints;
using FreightApp.Domain.Shipments;
using Marten;

namespace FreightAPI.Features.Shipments.CreateShipment;

public class CreateShipment : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/shipments",
            async (
                CreateShipmentRequest request,
                IDocumentSession session,
                CancellationToken cancellationToken
            ) =>
            {
                var shipment = new Shipment
                {
                    CustomerId = request.CustomerId,
                    Status = ShipmentStatus.Booked,
                    ReferenceNumbers = request.ReferenceNumbers,
                    Commodities = request.Commodities,
                };

                session.Store(shipment);
                await session.SaveChangesAsync(cancellationToken);

                return Results.Created($"/shipments/{shipment.Id}", shipment);
            }
        );
    }
}

public class CreateShipmentRequest
{
    public Guid CustomerId { get; set; }
    public List<ReferenceNumber> ReferenceNumbers { get; set; } = new();
    public List<Commodity> Commodities { get; set; } = new();
}
