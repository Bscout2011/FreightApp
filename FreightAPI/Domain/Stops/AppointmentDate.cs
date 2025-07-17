namespace FreightAPI.Domain.Stops;

public abstract record AppointmentDate
{
    public abstract DateTime StartDate { get; }

    public static AppointmentDate Fixed(DateTime dateTime) => new FixedAppointment(dateTime);

    public static AppointmentDate Range(DateTime start, DateTime end) =>
        new RangeAppointment(start, end);
}

public sealed record FixedAppointment(DateTime DateTime) : AppointmentDate
{
    public override DateTime StartDate => DateTime;
}

public sealed record RangeAppointment(DateTime Start, DateTime End) : AppointmentDate
{
    public override DateTime StartDate => Start;
    public bool IsValid => Start <= End;
}
