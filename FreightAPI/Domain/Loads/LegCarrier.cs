namespace FreightApp.Domain.Loads;

public class LegCarrier
{
    public Guid CarrierId { get; set; }
    public Guid DriverId { get; set; }
    public bool IsPrimary { get; set; } // To distinguish between primary and breakdown carrier
}
