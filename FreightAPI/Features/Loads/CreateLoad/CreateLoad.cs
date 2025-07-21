using FreightAPI.API.Endpoints;
using FreightApp.Domain.Loads;
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
                var load = new Load
                {
                    ShipmentId = request.ShipmentId,
                    Status = LoadStatus.Pending,
                };

                session.Store(load);
                await session.SaveChangesAsync(cancellationToken);

                return Results.Created($"/loads/{load.Id}", load);
            }
        );
    }
}

public class CreateLoadRequest
{
    public Guid ShipmentId { get; set; }
}
