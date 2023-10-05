using Dhanman.Infrastructure.Authentication.Constants;
using dhanman.money.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Dhanman.Infrastructure.Authentication.Providers;

internal sealed class UserIdentifierProvider : IUserIdentifierProvider
{
    #region Properties
    public Guid UserId { get; }
    #endregion

    #region Constructors
    public UserIdentifierProvider(IHttpContextAccessor httpContextAccessor)
    {
        string userIdClaim = httpContextAccessor.HttpContext?.User?.FindFirstValue(DhanmanJwtClaimTypes.UserId)
            ?? throw new ArgumentException("The user identifier claim is required.", nameof(httpContextAccessor));

        UserId = new Guid(userIdClaim);
    }
    #endregion

}