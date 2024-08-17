namespace Domain.Transactions;

public class Payment
{
    public int payment_id { get; set; }
    public string card_number { get; set; }
    public DateTime? payment_date { get; set; }
    public decimal amount { get; set; }
    public string status { get; set; }
}
