using Application.Abstractions.Data;
using Infrastructure.Database;
using Infrastructure.Details;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IApplicationDbContext, DbContext>();
        services.AddTransient<IDetailsQuery, DetailsQuery>();

    }
}
