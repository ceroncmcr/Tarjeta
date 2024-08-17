namespace Domain.Transactions;

public class History
{
    public string card_number { get; set; }
    public DateTime? payment_date { get; set; }
    public string transaction_type { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
}
