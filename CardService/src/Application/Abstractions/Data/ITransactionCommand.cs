using Domain.Transactions;

namespace Application.Abstractions.Data;

public interface ITransactionCommand
{
    Task<int> CreatePurchase(Purchase purchase);
    Task<int> CreatePayment(Payment purchase);
}
