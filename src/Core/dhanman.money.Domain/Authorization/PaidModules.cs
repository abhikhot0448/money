namespace dhanman.money.Domain.Authorization;

[Flags]
public enum PaidModules : long
{
    /// <summary>
    /// The default empty module.
    /// </summary>
    None = 0,

    /// <summary>
    /// The linked expenses module.
    /// </summary>
    LinkedExpenses = 1
}
