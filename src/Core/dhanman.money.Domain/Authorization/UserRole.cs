namespace dhanman.money.Domain.Authorization;

public sealed class UserRole
{
    #region Properties
    public Guid UserId { get; }

    public string RoleName { get; }
    #endregion

    #region Constructors
    public UserRole(Guid userId, string roleName)
       : this()
    {
        UserId = userId;
        RoleName = roleName;
    }

    private UserRole()
    {
        RoleName = string.Empty;
    }
    #endregion

}
