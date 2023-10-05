namespace dhanman.money.Application.Contracts.Invoice;

public class InvoiceResponse
{
    #region Properties
    public Guid Id { get; }
    public Guid InvoicePaymentId { get; private set; }
    public string InvoiceNumber { get; private set; }
    public string InvoiceVoucher { get; private set; }
    public Guid COAId { get; private set; }
    public DateTime InvoiceDate { get; private set; }
    public int? PaymentTerm { get; private set; }
    public string CustomerName { get; private set; }
    public DateTime DueDate { get; private set; }
    public decimal TotalAmount { get; private set; }
    public decimal Tax { get; private set; }
    public decimal Discount { get; private set; }
    public string InvoiceStatus { get; private set; }
    public string Note { get; private set; }
    public DateTime CreatedOnUtc { get; }
    public string Currency { get; private set; }
    public List<InvoiceLine> Lines { get; private set; }
    #endregion

    #region Constructors
    public InvoiceResponse(Guid id,
   Guid invoicePaymentId,
   string invoiceNumber,
   string invoiceVoucher,
   Guid cOAId,
   string customerName,
   DateTime dueDate,
   DateTime invoiceDate,
   int? paymentTerm,
   decimal totalAmount,
   string currency,
   string invoiceStatus,
   decimal tax,
   decimal discount,
   string note,
   DateTime createdOnUtc,
   List<InvoiceLine> lines)
    {
        Id = id;
        InvoicePaymentId = invoicePaymentId;
        InvoiceNumber = invoiceNumber;
        InvoiceVoucher = invoiceVoucher;
        COAId = cOAId;
        InvoiceDate = invoiceDate;
        PaymentTerm = paymentTerm;
        CustomerName = customerName;
        DueDate = dueDate;
        TotalAmount = totalAmount;
        Tax = tax;
        Discount = discount;
        Note = note;
        Lines = lines;
        Currency = currency;
        InvoiceStatus = invoiceStatus;
        Tax = tax;
        CreatedOnUtc = createdOnUtc;
    }
    #endregion

}
