using Domain.Transactions;

namespace Application.Abstractions.Documents;

public interface ICreateDocument
{
    Task<byte[]> CreateAccountStatement(string CardNumber, int Month, IEnumerable<History> histories);
}
