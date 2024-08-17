using Application.Abstractions.Data;
using Infrastructure.Database;
using Infrastructure.Details;
using Infrastructure.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IApplicationDbContext, DbContext>();
        services.AddScoped<IDetailsQuery, DetailsQuery>();
        services.AddScoped<ITransactionQuery, TransactionQuery>();
        services.AddScoped<ITransactionCommand, TransactionCommand>();

    }
}
