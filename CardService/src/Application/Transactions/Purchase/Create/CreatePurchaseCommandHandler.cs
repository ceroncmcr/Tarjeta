using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using AutoMapper;
using Shared;

namespace Application.Transactions.Purchase.Create;

internal sealed class CreatePurchaseCommandHandler : ICommandHandler<CreatePurchaseCommand, CreatePurchaseResponse>
{
    private readonly ITransactionCommand _transactionCommand;
    private readonly IMapper _mapper;

    public CreatePurchaseCommandHandler(
        ITransactionCommand transactionCommand,
        IMapper mapper
    )
    {
        _transactionCommand = transactionCommand;
        _mapper = mapper;
    }

    public async Task<Result<CreatePurchaseResponse>> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    {        
        var purchase = _mapper.Map<Domain.Transactions.Purchase>(request);

        var id = await _transactionCommand.CreatePurchase(purchase);

        if (id <= 0) {            
            return Result.Failure<CreatePurchaseResponse>(new Error("500", "Ocurrio un error al realizar la compra", ErrorType.Failure));
        }

        return new CreatePurchaseResponse {  Id = id };
    }
}
