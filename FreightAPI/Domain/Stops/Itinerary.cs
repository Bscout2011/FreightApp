namespace FreightAPI.Domain.Stops;

public class Itinerary
{
    List<EmbeddedStop> stops = [];
    public IReadOnlyList<EmbeddedStop> Stops => stops.AsReadOnly();

    public Itinerary(IEnumerable<EmbeddedStop> stops)
    {
        stops = stops.ToList();
    }

    public void AddStop(int index, EmbeddedStop stop)
    {
        if (index < 0 || index > stops.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        stops.Insert(index, stop);
    }

    public void RemoveStop(int index)
    {
        if (index < 0 || index >= stops.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        stops.RemoveAt(index);
    }
}
