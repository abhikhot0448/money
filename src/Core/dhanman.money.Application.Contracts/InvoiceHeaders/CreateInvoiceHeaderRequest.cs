namespace dhanman.money.Application.Contracts.InvoiceHeaders;

public class CreateInvoiceHeaderRequest
{
    #region Properties
    public Guid COAId { get; private set; }
    public Guid InvoiceHeaderId { get; private set; }
    public string InvoiceNumber { get; private set; }
    public string InvoiceVoucher { get; private set; }
    public DateTime InvoiceDate { get; private set; }
    public int PaymentTerm { get; private set; }
    public Guid InvoiceStatusId { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid InvoicePaymentId { get; private set; }
    public DateTime DueDate { get; private set; }
    public Guid ClientId { get; private set; }
    public Guid UserId { get; set; }
    public decimal TotalAmount { get; private set; }
    public string Currency { get; private set; }
    public decimal Tax { get; private set; }
    public decimal Discount { get; private set; }
    public string Note { get; private set; }
    #endregion

    #region Constructors
    public CreateInvoiceHeaderRequest(
       Guid cOAId, Guid invoiceHeaderId, string invoiceNumber, string invoiceVoucher, DateTime invoiceDate, int paymentTerm,
       Guid invoiceStatusId, Guid customerId, Guid invoicePaymentId, DateTime dueDate, Guid clientId, Guid userId,
       decimal totalAmount, string currency, decimal tax, decimal discount, string note)
    {
        COAId = cOAId;
        InvoiceHeaderId = invoiceHeaderId;
        InvoiceNumber = invoiceNumber;
        InvoiceVoucher = invoiceVoucher;
        InvoiceDate = invoiceDate;
        PaymentTerm = paymentTerm;
        InvoiceStatusId = invoiceStatusId;
        CustomerId = customerId;
        InvoicePaymentId = invoicePaymentId;
        DueDate = dueDate;
        ClientId = clientId;
        UserId = userId;
        TotalAmount = totalAmount;
        Currency = currency;
        Tax = tax;
        Discount = discount;
        Note = note;
    }
    #endregion

}
