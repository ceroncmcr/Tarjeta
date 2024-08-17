using Application.Abstractions.Data;
using Dapper;
using Domain.Transactions;
using System.Data;

namespace Infrastructure.Transactions;

public class TransactionCommand : ITransactionCommand
{
    private readonly IApplicationDbContext _applicationDbContext;

    public TransactionCommand(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<int> CreatePurchase(Purchase purchase)
    {
        var p = new DynamicParameters();
        p.Add("@card_number", purchase.card_number, dbType: DbType.String, direction: ParameterDirection.Input);
        p.Add("@payment_date", purchase.payment_date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        p.Add("@description", purchase.Description, dbType: DbType.String, direction: ParameterDirection.Input);
        p.Add("@amount", purchase.Amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
        
        var connection = _applicationDbContext.GetConnectionSqlServer();
        var result = await connection.ExecuteAsync("add_purchase", p, commandType: CommandType.StoredProcedure);
        int id = p.Get<int>("@id");
        return id;
    }

    public async Task<int> CreatePayment(Payment purchase)
    {
        var p = new DynamicParameters();
        p.Add("@card_number", purchase.card_number, dbType: DbType.String, direction: ParameterDirection.Input);
        p.Add("@payment_date", purchase.payment_date, dbType: DbType.DateTime, direction: ParameterDirection.Input);        
        p.Add("@amount", purchase.amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
        p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
        
        var connection = _applicationDbContext.GetConnectionSqlServer();
        var result = await connection.ExecuteAsync("add_payment", p, commandType: CommandType.StoredProcedure);
        int id = p.Get<int>("@id");
        return id;
    }
}
