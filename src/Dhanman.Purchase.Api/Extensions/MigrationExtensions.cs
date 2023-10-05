using Dhanman.Money.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dhanman.Money.Api.Extensions;

public static class MigrationExtensions
{
   
    #region Methods
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Database.Migrate();
    }
    #endregion

}