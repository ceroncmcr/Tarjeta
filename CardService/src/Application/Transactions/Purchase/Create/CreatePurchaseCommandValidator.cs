using FluentValidation;

namespace Application.Transactions.Purchase.Create;

internal sealed class CreatePurchaseCommandValidator : AbstractValidator<CreatePurchaseCommand>
{
    public CreatePurchaseCommandValidator()
    {
        RuleFor(c => c.CardNumber).NotEmpty();
        RuleFor(c => c.PaymentDate).NotNull();
        RuleFor(c => c.Amount).NotEqual(0);
        RuleFor(c => c.Description).MinimumLength(3).MaximumLength(150);
    }
}
