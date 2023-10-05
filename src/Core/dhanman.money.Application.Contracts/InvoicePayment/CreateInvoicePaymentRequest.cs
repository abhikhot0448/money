namespace dhanman.money.Application.Contracts.InvoicePayment;

public class CreateInvoicePaymentRequest
{
    #region Properties
    public Guid UserId { get; }
    public Guid ClientId { get; }
    public decimal Amount { get;  private set; }
    public Guid InvoiceHeaderId { get;  private set; }
    public Guid TransactionId { get;  private set; }
    public Guid COAId { get;  set; }
    #endregion

    #region Constructors

    public CreateInvoicePaymentRequest(Guid userId, Guid clientId, decimal amount, Guid invoiceHeaderId, Guid transactionId, Guid cOAId)
    {
        UserId = userId;
        ClientId = clientId;
        Amount = amount;
        InvoiceHeaderId = invoiceHeaderId;
        TransactionId = transactionId;
        COAId = cOAId;
    }

    #endregion

}
