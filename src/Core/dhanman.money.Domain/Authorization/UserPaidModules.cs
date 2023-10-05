namespace dhanman.money.Domain.Authorization;

public sealed class UserPaidModules
{
    #region Properties
    public Guid UserId { get; }

    public PaidModules PaidModules { get; }
    #endregion

    #region Constructors

    private UserPaidModules()
    {
    }
    public UserPaidModules(Guid userId, PaidModules paidModules)
    : this()
    {
        UserId = userId;
        PaidModules = paidModules;
    }
    #endregion
      
}