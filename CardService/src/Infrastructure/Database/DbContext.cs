using Application.Abstractions.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Database;

internal class DbContext : IApplicationDbContext
{
    private readonly IConfiguration _configuration;
    private IDbConnection _dbConnection;
    public DbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public IDbConnection GetConnectionSqlServer()
    {
        var connectionString = _configuration.GetConnectionString("SqlServerConnection");
        _dbConnection = new SqlConnection(connectionString);

        return _dbConnection;
    }
}
