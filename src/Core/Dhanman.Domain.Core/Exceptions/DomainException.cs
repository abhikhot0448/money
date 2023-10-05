using B2aTech.CrossCuttingConcern.Core.Primitives;

namespace Dhanman.Domain.Core.Exceptions;

public class DomainException : Exception
{
    #region Properties
    public Error Error { get; }
    #endregion

    #region Constructors
    public DomainException(Error error) => Error = error;
    #endregion

}