using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Application.Details.Get;
using Shared;

namespace Application.Transactions.Purchase;

internal sealed class GetPurchaseQueryHandler : IQueryHandler<GetPurchaseQuery, IEnumerable<PurchaseResponse>>
{
    private readonly ITransactionQuery _transactionQuery;

    public GetPurchaseQueryHandler(ITransactionQuery transactionQuery)
    {
        _transactionQuery = transactionQuery;
    }
    public async Task<Result<IEnumerable<PurchaseResponse>>> Handle(GetPurchaseQuery request, CancellationToken cancellationToken)
    {
        var purchases = await _transactionQuery.GetPurchases(request.CardNumber, request.Month);

        if (!purchases.Any())
        {
            return Result.Failure<IEnumerable<PurchaseResponse>>(new Error("404", "No se encontraron registros", ErrorType.NotFound));
        }

        //TODO: Add automapper
        var response = new List<PurchaseResponse>();
        foreach (var purchase in purchases)
        {
            response.Add(new PurchaseResponse
            {
                CardNumber = purchase.card_number,
                PaymentDate = purchase.payment_date,
                Amount = purchase.Amount,
                Description = purchase.Description,
                TransactionType = purchase.transaction_type
            });
        }
        
        return response;
    }
}
