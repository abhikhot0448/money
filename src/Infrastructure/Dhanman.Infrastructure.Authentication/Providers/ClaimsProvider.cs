using Dhanman.Infrastructure.Authentication.Abstractions;
using Dhanman.Infrastructure.Authentication.Constants;
using Dhanman.Infrastructure.Authentication.Permissions;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Domain.Authorization;
using dhanman.money.Domain.Entities.Users;
using System.Security.Claims;

namespace Dhanman.Infrastructure.Authentication.Providers;

internal sealed class ClaimsProvider : IClaimsProvider
{
    #region Properties
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructors
    public ClaimsProvider(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methods
    public async Task<Claim[]> GetClaimsAsync(User user)
    {
        var claims = new List<Claim>()
            {
                new Claim(DhanmanJwtClaimTypes.UserId, user.Id.ToString()),
                new Claim(DhanmanJwtClaimTypes.Email, user.Email.Value),
                new Claim(DhanmanJwtClaimTypes.Name, $"{user.FirstName} {user.LastName}")
            };

        var permissionCalculator = new PermissionCalculator(_dbContext);

        Permission[] permissions = await PermissionCalculator.CalculatePermissionsForUserIdAsync(user.Id);

        IEnumerable<Claim> permissionClaims = permissions
            .Select(permission => new Claim(DhanmanJwtClaimTypes.Permissions, permission.ToString()));

        claims.AddRange(permissionClaims);

        return claims.ToArray();
    }
    #endregion

}
