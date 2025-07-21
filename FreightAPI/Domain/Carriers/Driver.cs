namespace FreightApp.Domain.Carriers;

public class Driver
{
    public Guid Id { get; set; }
    public Guid CarrierId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
