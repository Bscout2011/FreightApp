using FreightAPI.Domain.Locations;

namespace FreightAPI.Features.Locations;

public interface ILocationService
{
    Task<IEnumerable<GeoAddress>> SearchAddressesAsync(
        string query,
        string? country = null,
        int? limit = null,
        CancellationToken cancellationToken = default
    );
}
