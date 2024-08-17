namespace Web.Api.Controllers.Transactions.Request;

public class PaymentRequest
{
    public string CardNumber { get; set; }
    public DateTime? PaymentDate { get; set; } = DateTime.Now;
    public decimal Amount { get; set; }
}
