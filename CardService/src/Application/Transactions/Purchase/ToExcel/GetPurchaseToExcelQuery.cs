using Application.Abstractions.Messaging;

namespace Application.Transactions.Purchase.ToExcel;

public sealed class GetPurchaseToExcelQuery : IQuery<PurchaseToExcelResponse>
{
    public string CardNumber { get; set; }
    public int Month { get; set; }
}
