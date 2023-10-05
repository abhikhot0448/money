namespace Dhanman.Money.Domain.Exceptions.Base;

public abstract class BadRequestException : Exception
{
    #region Constructors
    protected BadRequestException(string message)
        : base(message)
    {
    }
    #endregion
}
