using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Transactions;
using Shared;

namespace Application.Transactions.Histories;

internal class GetHistoryQueryHandler : IQueryHandler<GetHistoryQuery, IEnumerable<HistoryResponse>>
{
    private readonly ITransactionQuery _transactionQuery;

    public GetHistoryQueryHandler(ITransactionQuery transactionQuery)
    {
        _transactionQuery = transactionQuery;
    }
    public async Task<Result<IEnumerable<HistoryResponse>>> Handle(GetHistoryQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<History> histories = await _transactionQuery.GetHistory(request.CardNumber, request.Month);

        if (!histories.Any())
        {
            return Result.Failure<IEnumerable<HistoryResponse>>(new Error("1", "No se encontraron registros", ErrorType.NotFound));
        }

        //TODO: Add automapper
        var response = new List<HistoryResponse>();
        foreach (var history in histories)
        {
            response.Add(new HistoryResponse
            {
                CardNumber = history.card_number,
                Amount = history.Amount,
                Description = history.Description,
                PaymentDate = history.payment_date,
                TransactionType = history.transaction_type
            });
        }

        return response;
    }
}
