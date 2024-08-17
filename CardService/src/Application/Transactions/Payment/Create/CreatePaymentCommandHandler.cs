using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Application.Transactions.Purchase.Create;
using Shared;

namespace Application.Transactions.Payment.Create;

internal sealed class CreatePaymentCommandHandler : ICommandHandler<CreatePaymentCommand, CreatePaymentResponse>
{
    private readonly ITransactionCommand _transactionCommand;

    public CreatePaymentCommandHandler(ITransactionCommand transactionCommand)
    {
        _transactionCommand = transactionCommand;
    }
    public async Task<Result<CreatePaymentResponse>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        //TODO: Add Automapper
        var payment = new Domain.Transactions.Payment
        {
            amount = request.Amount,
            card_number = request.CardNumber,            
            payment_date = request.PaymentDate
        };

        var id = await _transactionCommand.CreatePayment(payment);

        if (id <= 0)
        {
            return Result.Failure<CreatePaymentResponse>(new Error("500", "Ocurrio un error al realizar el pago", ErrorType.Failure));
        }

        return new CreatePaymentResponse { Id = id };
    }
}
