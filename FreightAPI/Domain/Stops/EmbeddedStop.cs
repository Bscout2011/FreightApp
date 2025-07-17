namespace FreightAPI.Domain.Stops;

public record EmbeddedStop(
    string Address,
    string City,
    string State,
    string ZipCode,
    AppointmentDate ScheduledAt
)
{
    public EmbeddedStop Reschedule(AppointmentDate scheduledAt) =>
        this with
        {
            ScheduledAt = scheduledAt,
        };
}
