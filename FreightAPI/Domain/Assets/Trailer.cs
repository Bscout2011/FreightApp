namespace FreightAPI.Domain.Assets;

public class Trailer : Equipment
{
    public string LicensePlate { get; set; } = string.Empty;
    public TrailerType Type { get; set; }
}