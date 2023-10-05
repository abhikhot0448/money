using Microsoft.AspNetCore.Builder;

namespace Dhanman.Money.Migrations.Core.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void ExecuteMigrations(this IApplicationBuilder builder, string connectionString)
        => MigrationsManager.ExecuteMigrations(connectionString);
}
