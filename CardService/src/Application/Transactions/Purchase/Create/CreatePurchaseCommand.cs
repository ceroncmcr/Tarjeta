using Application.Abstractions.Messaging;
namespace Application.Transactions.Purchase.Create;

public sealed class CreatePurchaseCommand : ICommand<CreatePurchaseResponse>
{
    public string CardNumber { get; set; }
    public DateTime PaymentDate { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
}
