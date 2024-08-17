using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using AutoMapper;
using Domain.Transactions;
using Shared;

namespace Application.Transactions.Histories;

internal class GetHistoryQueryHandler : IQueryHandler<GetHistoryQuery, IEnumerable<HistoryResponse>>
{
    private readonly ITransactionQuery _transactionQuery;
    private readonly IMapper _mapper;

    public GetHistoryQueryHandler(
        ITransactionQuery transactionQuery,
        IMapper mapper
    )
    {
        _transactionQuery = transactionQuery;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<HistoryResponse>>> Handle(GetHistoryQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<History> histories = await _transactionQuery.GetHistory(request.CardNumber, request.Month);

        if (!histories.Any())
        {
            return Result.Failure<IEnumerable<HistoryResponse>>(new Error("1", "No se encontraron registros", ErrorType.NotFound));
        }

        return _mapper.Map<List<HistoryResponse>>(histories);        
    }
}
