using Azure;
using Azure.Core;
using Azure.Maps.Search;
using Azure.Maps.Search.Models;
using FreightAPI.Domain.Locations;

namespace FreightAPI.Features.Locations;

public class LocationService : ILocationService
{
    private readonly AzureKeyCredential credential;
    private readonly MapsSearchClient client;
    private readonly ILogger<LocationService> logger;

    public LocationService(IConfiguration configuration, ILogger<LocationService> logger)
    {
        credential = new(
            configuration["AzureMaps:Key"] ?? throw new ArgumentNullException("AzureMaps:Key")
        );
        client = new MapsSearchClient(
            credential,
            new MapsSearchClientOptions { Retry = { MaxRetries = 3, Mode = RetryMode.Exponential } }
        );
        this.logger = logger;
    }

    public async Task<IEnumerable<GeoAddress>> SearchAddressesAsync(
        string query,
        string? country = null,
        int? limit = null,
        CancellationToken cancellationToken = default
    )
    {
        var geocodingResponse = await client.GetGeocodingAsync(query, null, cancellationToken);

        if (!geocodingResponse.HasValue)
        {
            logger.LogWarning("Geocoding query failed");
            return [];
        }
        var results = geocodingResponse.Value;

        return [];
    }
}
