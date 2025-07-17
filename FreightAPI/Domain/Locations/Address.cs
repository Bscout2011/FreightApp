namespace FreightAPI.Domain.Locations;

public class Address
{
    public required string Street { get; init; }
    public string? Suite { get; init; }
    public required string City { get; init; }
    public required string State { get; init; }
    public required string PostalCode { get; init; }
    public string? Country { get; init; }
}
