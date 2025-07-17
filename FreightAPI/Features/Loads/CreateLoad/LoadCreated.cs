using FreightAPI.API.Endpoints;
using FreightAPI.Domain.Loads;
using Marten;

namespace FreightAPI.Features.Loads.LoadCreated;

public record LoadCreatedRequest(string Origin, string Destination, DateTime ScheduledAt);

public class LoadCreatedEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "loads/create",
            async (LoadCreatedRequest request, IDocumentStore store) =>
            {
                await using var session = store.LightweightSession();
                var load = new Load()
                {
                    Origin = request.Origin,
                    Destination = request.Destination,
                    ScheduledAt = request.ScheduledAt,
                };

                session.Store(load);
                await session.SaveChangesAsync();
                return Results.Created($"/loads/{load.Id}", load);
            }
        );
    }
}
