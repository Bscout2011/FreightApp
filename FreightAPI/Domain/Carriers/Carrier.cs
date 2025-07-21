namespace FreightApp.Domain.Carriers;

public class Carrier
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string McNumber { get; set; } = string.Empty;
}
