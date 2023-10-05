namespace dhanman.money.Application.Contracts.Invoice;

public class CreateInvoiceRequest
{
    #region Properties
    public string InvoiceNumber { get; private set; }
    public string InvoiceVoucher { get; private set; }
    public DateTime InvoiceDate { get; private set; }
    public int? PaymentTerm { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid InvoicePaymentId { get; private set; }
    public DateTime DueDate { get; private set; }
    public decimal TotalAmount { get; private set; }
    public string Currency { get; private set; }
    public decimal Tax { get; private set; }
    public decimal Discount { get; private set; }
    public string Note { get; private set; }
    public Guid ClientId { get; private set; }
    public List<InvoiceLine> Lines { get; private set; }
    #endregion

    #region Constructors
    public CreateInvoiceRequest(
       string invoiceNumber, string invoiceVoucher, DateTime invoiceDate, int? paymentTerm, Guid customerId,
       Guid clientId, DateTime dueDate, decimal totalAmount, string currency, decimal tax, decimal discount,
       string note, List<InvoiceLine> lines)
    {
        InvoiceNumber = invoiceNumber;
        InvoiceVoucher = invoiceVoucher;
        InvoiceDate = invoiceDate;
        PaymentTerm = paymentTerm;
        CustomerId = customerId;
        ClientId = clientId;
        DueDate = dueDate;
        TotalAmount = totalAmount;
        Tax = tax;
        Discount = discount;
        Note = note;
        Lines = lines;
        Currency = currency;
    }
    #endregion

    #region Methodes

    #endregion

}
