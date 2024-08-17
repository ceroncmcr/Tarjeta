using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Shared;

namespace Application.Details.Get;

internal sealed class GetDetailsQueryHandler : IQueryHandler<GetDetailsQuery, DetailsResponse>
{
    private readonly IDetailsQuery _detailsQuery;

    public GetDetailsQueryHandler(IDetailsQuery detailsQuery)
    {
        _detailsQuery = detailsQuery;
    }
    public async Task<Result<DetailsResponse>> Handle(GetDetailsQuery request, CancellationToken cancellationToken)
    {
        var details = await _detailsQuery.GetDetailsCard(request.CardNumber);

        if (details is null)
        {
            return Result.Failure<DetailsResponse>(new Error("1", "No se encontro el numero de tarjeta", ErrorType.NotFound));
        }

        //TODO: Add AutoMapper
        var detailsResponse = new DetailsResponse
        {
            Name = details.Name,
            CardNumber = details.CardNumber,
            CurrentBalance = details.CurrentBalance,
            Limit = details.Limit,
            AvailableBalance = details.AvailableBalance,
            BonusableInterets = details.BonusableInterets,
            MinPaymentDue = details.MinPaymentDue,
            PaymentWithInterest = details.PaymentWithInterest
        };

        return detailsResponse;
    }
}
