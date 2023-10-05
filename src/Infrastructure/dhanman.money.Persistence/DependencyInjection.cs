using B2aTech.CrossCuttingConcern.Core.Abstractions;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Domain.Abstractions;
using dhanman.money.Persistence.Common;
using dhanman.money.Persistence.Data;
using dhanman.money.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dhanman.money.Persistence;

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
            services.AddScoped<IInvoiceStatusRepository, InvoiceStatusRepository>();
            services.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();
            services.AddScoped<IInvoicePaymentRepository, InvoicePaymentRepository>();
            services.AddScoped<IInvoiceHeaderRepository, InvoiceHeaderRepository>();
        }
        return services;
    }
    #endregion

}
