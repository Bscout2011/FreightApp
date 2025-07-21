namespace FreightAPI.Domain.Assets;

public abstract class Equipment
{
    public Guid Id { get; set; }
    public string UnitNumber { get; set; } = string.Empty;
}