using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using AutoMapper;
using Shared;

namespace Application.Transactions.Payment.Create;

internal sealed class CreatePaymentCommandHandler : ICommandHandler<CreatePaymentCommand, CreatePaymentResponse>
{
    private readonly ITransactionCommand _transactionCommand;
    private readonly IMapper _mapper;

    public CreatePaymentCommandHandler(
        ITransactionCommand transactionCommand,
        IMapper mapper
    )
    {
        _transactionCommand = transactionCommand;
        _mapper = mapper;
    }
    public async Task<Result<CreatePaymentResponse>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = _mapper.Map<Domain.Transactions.Payment>(request);

        var id = await _transactionCommand.CreatePayment(payment);

        if (id <= 0)
        {
            return Result.Failure<CreatePaymentResponse>(new Error("500", "Ocurrio un error al realizar el pago", ErrorType.Failure));
        }

        return new CreatePaymentResponse { Id = id };
    }
}
