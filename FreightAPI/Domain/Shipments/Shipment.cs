namespace FreightAPI.Domain.Shipments;

public class Shipment
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Origin { get; init; }
    public required string Destination { get; init; }
    public required DateTime ScheduledAt { get; init; }
    public DateTime? PickedUpAt { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public ShipmentStatus Status { get; set; } = ShipmentStatus.Pending;
}
