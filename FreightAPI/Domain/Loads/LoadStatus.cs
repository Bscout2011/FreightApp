namespace FreightAPI.Domain.Loads;

public enum LoadStatus
{
    Open = 10,
    InTransit = 100,
    Delivered = 200,
    Tonu = 900,
    Void = 999,
}
