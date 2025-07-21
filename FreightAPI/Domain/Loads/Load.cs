using FreightAPI.Domain.Assets;
using FreightApp.Domain.Loads;
using FreightApp.Domain.Stops;

namespace FreightAPI.Domain.Loads;

public class Load
{
    public Guid Id { get; set; }
    public Guid ShipmentId { get; set; }
    public LoadStatus Status { get; set; }

    // The full list of stops for the entire load
    public List<Stop> Stops { get; set; } = new();

    // Defines the journey between stops and the carriers assigned
    public List<Leg> Legs { get; set; } = new();

    public List<Equipment> AllocatedEquipment { get; set; } = [];
}
