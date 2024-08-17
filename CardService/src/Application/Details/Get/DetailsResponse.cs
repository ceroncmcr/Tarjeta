namespace Application.Details.Get;

public sealed class DetailsResponse
{
    public string Name { get; set; }
    public string CardNumber { get; set; }
    public decimal CurrentBalance { get; set; }
    public decimal Limit { get; set; }
    public decimal AvailableBalance { get; set; }
    public decimal BonusableInterets { get; set; }
    public decimal MinPaymentDue { get; set; }
    public decimal PaymentWithInterest { get; set; }
}
