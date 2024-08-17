﻿using Application.Abstractions.Data;
using Application.Abstractions.Documents;
using Infrastructure.Database;
using Infrastructure.Details;
using Infrastructure.Documents;
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

        services.AddScoped<ICreateDocument, CreateDocument>();

    }
}
