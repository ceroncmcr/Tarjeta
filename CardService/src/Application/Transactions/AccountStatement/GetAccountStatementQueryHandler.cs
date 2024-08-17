using Application.Abstractions.Data;
using Application.Abstractions.Documents;
using Application.Abstractions.Messaging;
using Shared;

namespace Application.Transactions.AccountStatement;

internal sealed class GetAccountStatementQueryHandler : IQueryHandler<GetAccountStatementQuery, AccountStatementResponse>
{
    private readonly ITransactionQuery _transactionQuery;
    private readonly ICreateDocument _createDocument;

    public GetAccountStatementQueryHandler(
        ITransactionQuery transactionQuery,
        ICreateDocument createDocument
    )
    {
        _transactionQuery = transactionQuery;
        _createDocument = createDocument;
    }
    public async Task<Result<AccountStatementResponse>> Handle(GetAccountStatementQuery request, CancellationToken cancellationToken)
    {
        var accountStatement = await _transactionQuery.GetHistory(request.CardNumber, request.Month);

        if (!accountStatement.Any())
        {
            return Result.Failure<AccountStatementResponse>(new Error("1", "No se encontraron registros", ErrorType.NotFound));
        }

        byte[] pdf = await _createDocument.CreateAccountStatement(request.CardNumber, request.Month, accountStatement);

        return new AccountStatementResponse { b64 = pdf };
    }
}

