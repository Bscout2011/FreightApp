namespace FreightApp.Domain.Equipment;

public class Container : Equipment
{
    public string Size { get; set; } = string.Empty; // 20', 40', 40'HC
    public Guid SteamshipLineId { get; set; }
}
