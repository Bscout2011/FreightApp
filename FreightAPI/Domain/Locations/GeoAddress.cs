namespace FreightAPI.Domain.Locations;

public class GeoAddress : Address
{
    public required double Latitude { get; init; }
    public required double Longitude { get; init; }
    public string? Timezone { get; init; }
    public string? PlaceId { get; init; }
    public string? GeocodingProvider { get; init; } // e.g., "Google", "OpenStreetMap"
}
