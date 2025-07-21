namespace FreightApp.Domain.Shipments;

public class Commodity
{
    public string Description { get; set; } = string.Empty;
    public int Weight { get; set; }
    public string HandlingInstructions { get; set; } = string.Empty;
}
