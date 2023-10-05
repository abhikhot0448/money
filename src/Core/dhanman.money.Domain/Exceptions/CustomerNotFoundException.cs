using Dhanman.Money.Domain.Exceptions.Base;

namespace Dhanman.Money.Domain.Exceptions;

public sealed class CustomerNotFoundException : NotFoundException
{
    #region Constructor
    public CustomerNotFoundException(Guid customerId)
        : base($"The customer with the identifier {customerId} was not found.")
    {

    }
    #endregion
}
