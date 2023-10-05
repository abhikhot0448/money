namespace dhanman.money.Application.Contracts.InvoicePayment;

public class InvoicePaymentResponse
{
    #region Properties
    public Guid Id { get; }
    public Guid ClientId { get; }
    public decimal Amount { get; private set; }
    public Guid InvoiceHeaderId { get; private set; }
    public Guid TransactionId { get; private set; }
    public Guid COAId { get; private set; }
    public DateTime CreatedOnUtc { get; }

    #endregion

    #region Constructor
    public InvoicePaymentResponse(
     Guid id,
     Guid clientId,
     decimal amount,
     Guid invoiceHeaderId,
     Guid transactionId,
     Guid cOAId,
     DateTime createdOnUtc)
    {
        Id = id;
        ClientId = clientId;
        Amount = amount;
        InvoiceHeaderId = invoiceHeaderId;
        TransactionId = transactionId;
        COAId = cOAId;
        CreatedOnUtc = createdOnUtc;
    }
    #endregion
}
