using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using AutoMapper;
using Shared;

namespace Application.Transactions.Purchase.Get;

internal sealed class GetPurchaseQueryHandler : IQueryHandler<GetPurchaseQuery, IEnumerable<PurchaseResponse>>
{
    private readonly ITransactionQuery _transactionQuery;
    private readonly IMapper _mapper;

    public GetPurchaseQueryHandler(
        ITransactionQuery transactionQuery,
        IMapper mapper    
    )
    {
        _transactionQuery = transactionQuery;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<PurchaseResponse>>> Handle(GetPurchaseQuery request, CancellationToken cancellationToken)
    {
        var purchases = await _transactionQuery.GetPurchases(request.CardNumber, request.Month);

        if (!purchases.Any())
        {
            return Result.Failure<IEnumerable<PurchaseResponse>>(new Error("404", "No se encontraron registros", ErrorType.NotFound));
        }

        return _mapper.Map<List<PurchaseResponse>>(purchases);        
    }
}
