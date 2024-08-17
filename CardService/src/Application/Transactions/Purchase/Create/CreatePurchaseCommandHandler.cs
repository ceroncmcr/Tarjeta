using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Application.Transactions.Purchase.Get;
using Shared;

namespace Application.Transactions.Purchase.Create;

internal sealed class CreatePurchaseCommandHandler : ICommandHandler<CreatePurchaseCommand, CreatePurchaseResponse>
{
    private readonly ITransactionCommand _transactionCommand;

    public CreatePurchaseCommandHandler(ITransactionCommand transactionCommand)
    {
        _transactionCommand = transactionCommand;
    }

    public async Task<Result<CreatePurchaseResponse>> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    {
        //TODO: Add Automapper
        var purchase = new Domain.Transactions.Purchase
        {
            Amount = request.Amount,
            card_number = request.CardNumber,
            Description = request.Description,
            payment_date = request.PaymentDate
        };

        var id = await _transactionCommand.CreatePurchase(purchase);

        if (id <= 0) {            
            return Result.Failure<CreatePurchaseResponse>(new Error("500", "Ocurrio un error al realizar la compra", ErrorType.Failure));
        }

        return new CreatePurchaseResponse {  Id = id };
    }
}
