﻿using Application.Abstractions.Data;
using Dapper;
using Domain.Transactions;

namespace Infrastructure.Transactions;

public class TransactionQuery : ITransactionQuery
{
    private readonly IApplicationDbContext _applicationDbContext;

    public TransactionQuery(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<Purchase>> GetPurchases(string CardNumber, int Month)
    {
        var _query = "exec get_purchase @CardNumber, @Month";
        var connection = _applicationDbContext.GetConnectionSqlServer();
        var purchases = await connection.QueryAsync<Purchase>(_query, new { CardNumber, Month });
        return purchases;
    }

    public async Task<IEnumerable<History>> GetHistory(string CardNumber, int Month)
    {
        var _query = "exec transaction_history @CardNumber, @Month";
        var connection = _applicationDbContext.GetConnectionSqlServer();
        var purchases = await connection.QueryAsync<History>(_query, new { CardNumber, Month });
        return purchases;
    }
}
