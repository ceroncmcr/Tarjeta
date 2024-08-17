using Application.Abstractions.Data;
using Dapper;
using Domain.Details;
using Domain.Transactions;

namespace Infrastructure.Transactions;

public class TransactionQuery : ITransactionQuery
{
    private readonly IApplicationDbContext _applicationDbContext;

    public TransactionQuery(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<Purchase>> GetPurchases(string NumeroTarjeta, int Month)
    {
        var _query = "exec get_purchase @NumeroTarjeta, @Month";
        var connection = _applicationDbContext.GetConnectionSqlServer();
        var purchases = await connection.QueryAsync<Purchase>(_query, new { NumeroTarjeta, Month });
        return purchases;
    }
}
