using Application.Abstractions.Data;
using Application.Abstractions.Documents;
using Application.Abstractions.Messaging;
using Application.Transactions.AccountStatement;
using Application.Transactions.Purchase.Get;
using Shared;

namespace Application.Transactions.Purchase.ToExcel;

internal sealed class GetPurchaseToExcelQueryHandler : IQueryHandler<GetPurchaseToExcelQuery, PurchaseToExcelResponse>
{
    private readonly ITransactionQuery _transactionQuery;
    private readonly ICreateDocument _createDocument;

    public GetPurchaseToExcelQueryHandler(
        ITransactionQuery transactionQuery,
        ICreateDocument createDocument
    )
    {
        _transactionQuery = transactionQuery;
        _createDocument = createDocument;
    }
    public async Task<Result<PurchaseToExcelResponse>> Handle(GetPurchaseToExcelQuery request, CancellationToken cancellationToken)
    {
        var purchases = await _transactionQuery.GetPurchases(request.CardNumber, request.Month);

        if (!purchases.Any())
        {
            return Result.Failure<PurchaseToExcelResponse>(new Error("404", "No se encontraron registros", ErrorType.NotFound));
        }

        byte[] pdf = await _createDocument.CreateDetailsPurchase(request.CardNumber, request.Month, purchases);

        return new PurchaseToExcelResponse { b64 = pdf };
    }
}
