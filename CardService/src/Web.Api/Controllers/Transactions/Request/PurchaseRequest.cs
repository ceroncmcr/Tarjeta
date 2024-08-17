namespace Web.Api.Controllers.Transactions.Request;

public class PurchaseRequest
{
    public string CardNumber { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.Now;
    public string Description { get; set; }
    public decimal Amount { get; set; }
}
