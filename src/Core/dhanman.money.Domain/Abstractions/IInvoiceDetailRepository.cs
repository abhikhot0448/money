using dhanman.money.Domain.Entities.InvoiceDetails;

namespace dhanman.money.Domain.Abstractions;

public interface IInvoiceDetailRepository
{
    #region Methodes

    Task<InvoiceDetail?> GetByIdAsync(Guid id);
    void Insert(InvoiceDetail invoiceDetail);

    #endregion
}
