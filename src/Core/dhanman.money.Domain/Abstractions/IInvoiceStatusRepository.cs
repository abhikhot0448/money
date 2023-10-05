using dhanman.money.Domain.Entities.InvoiceStatuses;

namespace dhanman.money.Domain.Abstractions;

public interface IInvoiceStatusRepository
{
    #region Methodes

    Task<InvoiceStatus?> GetByIdAsync(Guid id);

    Task<bool> IsInvoiceStatusUniqueAsync(string name);
    void Insert(InvoiceStatus invoiceStatus);

    #endregion
}
