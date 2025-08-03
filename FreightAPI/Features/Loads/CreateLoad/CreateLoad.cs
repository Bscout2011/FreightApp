using FreightAPI.API.Endpoints;
using FreightAPI.Domain.Loads;
using FreightApp.Domain.Shipments;
using Marten;

namespace FreightAPI.Features.Loads.CreateLoad;

public class CreateLoad : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/loads",
            async (
                CreateLoadRequest request,
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

                var load = new Load { ShipmentId = shipment.Id, Status = LoadStatus.Open };

                shipment.LoadIds.Add(load.Id);

                session.Store(load);
                await session.SaveChangesAsync(cancellationToken);

                return Results.Created($"/loads/{load.Id}", load);
            }
        );
    }
}

public class CreateLoadRequest
{
    public Guid CustomerId { get; set; }
    public List<ReferenceNumber> ReferenceNumbers { get; set; } = new();
    public List<Commodity> Commodities { get; set; } = new();
}
