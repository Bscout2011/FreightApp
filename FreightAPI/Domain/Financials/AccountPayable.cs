namespace FreightApp.Domain.Financials;

public class AccountPayable
{
    public Guid Id { get; set; }
    public Guid LoadId { get; set; }
    public Guid CarrierId { get; set; }
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsPaid { get; set; }
}
