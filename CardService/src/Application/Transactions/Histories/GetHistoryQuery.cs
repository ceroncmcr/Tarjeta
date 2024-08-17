using Application.Abstractions.Messaging;

namespace Application.Transactions.Histories;

public sealed class GetHistoryQuery : IQuery<IEnumerable<HistoryResponse>>
{
    public string CardNumber { get; set; }
    public int Month { get; set; }
}
