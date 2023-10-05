using dhanman.money.Domain.Exceptions.Base;

namespace dhanman.money.Domain.Exceptions;

public class InvoiceStatusNotFoundException : NotFoundException
{
    #region Constructors
    public InvoiceStatusNotFoundException(Guid invoiceStatusId)
   : base($"The invoice status with the identifier {invoiceStatusId} was not found.")
    {

    }
    #endregion
}
