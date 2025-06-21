using FreightAPI.API.Endpoints;
using FreightAPI.Domain.Shipments;
using Marten;
using Marten.Linq;

namespace FreightAPI.API.Shipments;

public class FetchShipmentsRequest
{
    public string? Origin { get; set; }
    public string? Destination { get; set; }
    public DateTime? ScheduledAfter { get; set; }
    public DateTime? ScheduledBefore { get; set; }

    public async Task<IReadOnlyList<Shipment>> QueryAsync(
        IQuerySession session,
        CancellationToken cancellationToken = default
    )
    {
        IQueryable<Shipment> query = session.Query<Shipment>();
        if (!string.IsNullOrEmpty(Origin))
        {
            query = query.Where(s => s.Origin.Contains(Origin, StringComparison.OrdinalIgnoreCase));
        }
        if (!string.IsNullOrEmpty(Destination))
        {
            query = query.Where(s =>
                s.Destination.Contains(Destination, StringComparison.OrdinalIgnoreCase)
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

public class FetchShipments : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "shipments/fetch",
            async (
                FetchShipmentsRequest request,
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
