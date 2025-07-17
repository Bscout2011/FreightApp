using FreightAPI.Domain.Locations.Facilities;
using FreightAPI.Domain.Stops;

namespace FreightAPI.Domain.Loads;

public class Load
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Itinerary? Itinerary { get; set; }
    public string? Origin { get; set; }
    public string? Destination { get; set; }
    public DateTime? ScheduledAt { get; set; }
    public LoadStatus Status { get; set; } = LoadStatus.Open;
}
