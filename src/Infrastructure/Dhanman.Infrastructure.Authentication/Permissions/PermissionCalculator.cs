using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Domain.Authorization;

namespace Dhanman.Infrastructure.Authentication.Permissions;

internal sealed class PermissionCalculator
{
    #region Properties
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructors
    internal PermissionCalculator(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methodes

    internal static async Task<Permission[]> CalculatePermissionsForUserIdAsync(Guid userId)
    {
        await Task.Delay(1);

        return new[]
        {
                Permission.AccessEverything
        };
    }
    #endregion

}