using FreightAPI.API.Endpoints;
using FreightAPI.Domain.Loads;
using Marten;

namespace FreightAPI.API.Loads;

public class QueryLoadsRequest
{
    public string? Origin { get; set; }
    public string? Destination { get; set; }
    public DateTime? ScheduledAfter { get; set; }
    public DateTime? ScheduledBefore { get; set; }

    public async Task<IReadOnlyList<Load>> QueryAsync(
        IQuerySession session,
        CancellationToken cancellationToken = default
    )
    {
        IQueryable<Load> query = session.Query<Load>();
        if (!string.IsNullOrEmpty(Origin))
        {
            query = query.Where(s => s.Origin != null && s.Origin.Contains(Origin, StringComparison.OrdinalIgnoreCase));
        }
        if (!string.IsNullOrEmpty(Destination))
        {
            query = query.Where(s =>
                s.Destination != null && s.Destination.Contains(Destination, StringComparison.OrdinalIgnoreCase)
            );
        }
        if (ScheduledAfter.HasValue)
        {
            query = query.Where(s => s.ScheduledAt >= ScheduledAfter.Value);
        }
        if (ScheduledBefore.HasValue)
        {
            query = query.Where(s => s.ScheduledAt <= ScheduledBefore.Value);
        }
        return await query.ToListAsync(cancellationToken);
    }
}

public class ListLoads : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "loads/list",
            async (
                QueryLoadsRequest request,
                IQuerySession session,
                CancellationToken cancellationToken = default
            ) =>
            {
                var shipments = await request.QueryAsync(session, cancellationToken);

                return Results.Ok(shipments);
            }
        );
    }
}
