﻿using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }
    public static void ConfigurePostgresContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetValue<string>("ConnectionStrings:dbConn");

        services.AddDbContext<RepositoryContext>(o => o.UseNpgsql(connectionString));
    }

    public static void ConfigureRepositoryWrapper(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
}