using dhanman.money.Domain.Entities.InvoiceHeaders;

namespace dhanman.money.Domain.Abstractions;

public interface IInvoiceHeaderRepository
{
    #region Methodes

    Task<InvoiceHeader?> GetByIdAsync(Guid id);
    void Insert(InvoiceHeader invoiceHeader);
    Task<bool> IsInvoiceNumberUniqueAsync(string invoiceNumber);

    #endregion
}
