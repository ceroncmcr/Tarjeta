using Application.Abstractions.Messaging;

namespace Application.Transactions.Payment.Create;

public sealed class CreatePaymentCommand : ICommand<CreatePaymentResponse>
{
    public string CardNumber { get; set; }
    public DateTime? PaymentDate { get; set; } = DateTime.Now;
    public decimal Amount { get; set; }
}
