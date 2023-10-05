using dhanman.money.Domain.Exceptions.Base;

namespace dhanman.money.Domain.Exceptions;

public sealed class CustomerNotFoundException : NotFoundException
{
    #region Constructor
    public CustomerNotFoundException(Guid customerId)
        : base($"The customer with the identifier {customerId} was not found.")
    {

    }
    #endregion
}
