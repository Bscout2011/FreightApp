namespace FreightApp.Domain.Equipment;

public abstract class Equipment
{
    public Guid Id { get; set; }
    public string UnitNumber { get; set; } = string.Empty;
}
