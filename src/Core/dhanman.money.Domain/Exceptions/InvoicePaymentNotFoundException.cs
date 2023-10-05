using dhanman.money.Domain.Exceptions.Base;

namespace dhanman.money.Domain.Exceptions;

public class InvoicePaymentNotFoundException : NotFoundException
{
    #region Constructors
    public InvoicePaymentNotFoundException(Guid InvoicePaymentId)
            : base($"The invoice status with the identifier {InvoicePaymentId} was not found.")
    {
    }
    #endregion
}
