using System.Collections.Generic;
using FreightAPI.Domain.Locations.Facilities;
using FreightApp.Domain.Equipment;
using FreightApp.Domain.Stops;

namespace FreightApp.Domain.Loads;

public class Load
{
    public Guid Id { get; set; }
    public Guid ShipmentId { get; set; }
    public LoadStatus Status { get; set; }

    // The full list of stops for the entire load
    public List<Stop> Stops { get; set; } = new();

    // Defines the journey between stops and the carriers assigned
    public List<Leg> Legs { get; set; } = new();

    public List<Equipment> AssignedEquipment { get; set; } = new();
}
