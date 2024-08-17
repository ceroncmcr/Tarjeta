using System.Data;

namespace Application.Abstractions.Data;

public interface IApplicationDbContext
{
    IDbConnection GetConnectionSqlServer();
}
