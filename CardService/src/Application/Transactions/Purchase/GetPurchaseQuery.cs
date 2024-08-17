using Application.Abstractions.Messaging;

namespace Application.Transactions.Purchase;

public sealed record GetPurchaseQuery : IQuery<IEnumerable<PurchaseResponse>>
{
    public string CardNumber { get; set; }
    public int Month { get; set; }
}
