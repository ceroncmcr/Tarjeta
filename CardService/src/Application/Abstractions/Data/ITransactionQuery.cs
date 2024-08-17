using Domain.Transactions;

namespace Application.Abstractions.Data;

public interface ITransactionQuery
{
    Task<IEnumerable<Purchase>> GetPurchases(string NumeroTarjeta, int Month);
    Task<IEnumerable<History>> GetHistory(string CardNumber, int Month);
}
