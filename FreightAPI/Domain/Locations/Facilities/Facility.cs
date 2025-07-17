namespace FreightAPI.Domain.Locations.Facilities;

public class Facility
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Name { get; init; }
    public required string Type { get; init; } // e.g., "Warehouse", "Distribution Center", "Retail Store"
    public required GeoAddress Address { get; init; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}
