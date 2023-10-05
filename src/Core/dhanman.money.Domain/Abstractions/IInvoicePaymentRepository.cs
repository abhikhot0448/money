using dhanman.money.Domain.Entities.InvoicePayments;

namespace dhanman.money.Domain.Abstractions;

public interface IInvoicePaymentRepository
{
    #region Methodes

    Task<InvoicePayment?> GetByIdAsync(Guid id);
    void Insert(InvoicePayment invoicePayment);

    #endregion
}
