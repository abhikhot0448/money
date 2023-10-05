namespace dhanman.money.Domain.Authorization.Attributes;

public sealed class LinkedToModuleAttribute : Attribute
{
    #region Properties
    public PaidModules PaidModules { get; }
    #endregion

    #region Constructors
    public LinkedToModuleAttribute(PaidModules paidModules) => PaidModules = paidModules;

    #endregion
}
