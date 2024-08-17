using Application.Abstractions.Messaging;

namespace Application.Details.Get;

public sealed record GetDetailsQuery : IQuery<DetailsResponse>
{
    public string CardNumber { get; set; }
}
