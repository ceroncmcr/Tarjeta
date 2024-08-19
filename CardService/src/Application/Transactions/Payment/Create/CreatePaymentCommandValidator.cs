using FluentValidation;

namespace Application.Transactions.Payment.Create;

internal sealed class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(c => c.CardNumber).NotEmpty().WithMessage("El numero de tarjeta es requerido");
        RuleFor(c => c.PaymentDate).NotNull();
        RuleFor(c => c.Amount).NotEqual(0);
    }
}
