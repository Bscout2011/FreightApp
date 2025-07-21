namespace FreightApp.Domain.Stops;

public class Stop
{
    public Guid Id { get; set; }
    public int Sequence { get; set; }
    public Guid LocationId { get; set; }
    public StopType Type { get; set; }
    public DateTime AppointmentTime { get; set; }
}
