namespace FreightApp.Domain.Locations;

public class Location
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Address Address { get; set; } = new();
}
