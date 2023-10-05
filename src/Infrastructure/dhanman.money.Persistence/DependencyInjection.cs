using B2aTech.CrossCuttingConcern.Core.Abstractions;
using Dhanman.Money.Application.Abstractions.Data;
using Dhanman.Money.Domain.Abstractions;
using Dhanman.Money.Persistence.Common;
using Dhanman.Money.Persistence.Data;
using Dhanman.Money.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dhanman.Money.Persistence;

public static class DependencyInjection
{

    #region Methods
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        if (configuration != null)
        {
            string connectionString = configuration.GetConnectionString(ConnectionString.SettingsKey);

            services.AddSingleton(new ConnectionString(connectionString));

            if (connectionString.Length > 0)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options
                        .UseNpgsql(connectionString)
                        .UseSnakeCaseNamingConvention()
                        .EnableSensitiveDataLogging());
            }

            services.AddTransient<IDateTime, MachineDateTime>();

            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();

            services.AddScoped<IDbExecutor, DbExecutor>();


            services.AddScoped<IApplicationDbContext>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUnitOfWork>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
           
        }
        return services;
    }
    #endregion

}
