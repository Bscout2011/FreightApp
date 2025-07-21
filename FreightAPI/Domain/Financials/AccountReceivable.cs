namespace FreightApp.Domain.Financials;

public class AccountReceivable
{
    public Guid Id { get; set; }
    public Guid ShipmentId { get; set; }
    public Guid CustomerId { get; set; }
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsPaid { get; set; }
}
