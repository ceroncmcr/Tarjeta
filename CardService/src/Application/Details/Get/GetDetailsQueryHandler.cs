using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using AutoMapper;
using Shared;

namespace Application.Details.Get;

internal sealed class GetDetailsQueryHandler : IQueryHandler<GetDetailsQuery, DetailsResponse>
{
    private readonly IDetailsQuery _detailsQuery;
    private readonly IMapper _mapper;

    public GetDetailsQueryHandler(
        IDetailsQuery detailsQuery,
        IMapper mapper
    )
    {
        _detailsQuery = detailsQuery;
        _mapper = mapper;
    }
    public async Task<Result<DetailsResponse>> Handle(GetDetailsQuery request, CancellationToken cancellationToken)
    {
        var details = await _detailsQuery.GetDetailsCard(request.CardNumber);

        if (details is null)
        {
            return Result.Failure<DetailsResponse>(new Error("1", "No se encontro el numero de tarjeta", ErrorType.NotFound));
        }

        return _mapper.Map<DetailsResponse>(details);
    }
}
