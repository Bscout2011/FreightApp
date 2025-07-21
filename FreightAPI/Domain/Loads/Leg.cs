namespace FreightApp.Domain.Loads;

public class Leg
{
    public Guid OriginStopId { get; set; }
    public Guid DestinationStopId { get; set; }
    public List<LegCarrier> Carriers { get; set; } = new();
}
