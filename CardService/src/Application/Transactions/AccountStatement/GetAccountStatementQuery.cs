using Application.Abstractions.Messaging;

namespace Application.Transactions.AccountStatement;

public sealed class GetAccountStatementQuery : IQuery<AccountStatementResponse>
{
    public string CardNumber { get; set; }
    public int Month { get; set; }
}
