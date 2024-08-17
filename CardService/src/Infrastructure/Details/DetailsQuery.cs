using Application.Abstractions.Data;
using Dapper;
using Domain.Details;
using Infrastructure.Database;

namespace Infrastructure.Details;
public class DetailsQuery : IDetailsQuery
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DetailsQuery(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<DetailsCard> GetDetailsCard(string NumeroTarjeta)
    {
        var _query = "exec details_card @NumeroTarjeta";
        var connection = _applicationDbContext.GetConnectionSqlServer();
        var details = await connection.QueryFirstOrDefaultAsync<DetailsCard>(_query, new { NumeroTarjeta });        
        return details;
    }

}
