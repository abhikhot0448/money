using Microsoft.AspNetCore.Authorization;

namespace Dhanman.Infrastructure.Authentication.Permissions;

internal sealed class PermissionRequirement : IAuthorizationRequirement
{
    #region Properties
    internal string PermissionName { get; }
    #endregion

    #region Constructors
    internal PermissionRequirement(string permissionName) => PermissionName = permissionName;
    #endregion

}