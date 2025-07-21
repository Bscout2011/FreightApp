using System.Collections.Generic;

namespace FreightApp.Domain.Shipments;

public class Shipment
{
    public Guid Id { get; set; }
    public List<ReferenceNumber> ReferenceNumbers { get; set; } = new();
    public Guid CustomerId { get; set; }
    public ShipmentStatus Status { get; set; }
    public List<Commodity> Commodities { get; set; } = new();
    public List<Guid> LoadIds { get; set; } = new();
}
