namespace dhanman.money.Domain.Exceptions.Base;

public abstract class NotFoundException : Exception
{
    #region Constructor
    protected NotFoundException(string message)
        : base(message)
    {
    }
    #endregion
}
