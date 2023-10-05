namespace dhanman.money.Application.Contracts.InvoiceHeaders;

public class InvoiceHeaderResponse
{
    #region Properties
    public Guid Id { get; }
    public Guid InvoicePaymentId { get; private set; }
    public string InvoiceNumber { get; private set; }
    public string InvoiceVoucher { get; private set; }
    public Guid COAId { get; private set; }
    public DateTime InvoiceDate { get; private set; }
    public int? PaymentTerm { get; private set; }
    public Guid InvoiceStatusId { get; private set; }
    public Guid CustomerId { get; private set; }
    public string Currency { get; private set; }
    public DateTime DueDate { get; private set; }
    public decimal TotalAmount { get; private set; }
    public decimal Tax { get; private set; }
    public decimal Discount { get; private set; }
    public string Note { get; private set; }
    public DateTime CreatedOnUtc { get; }
    #endregion

    #region Constructors
    public InvoiceHeaderResponse(Guid id,

        Guid invoicePaymentId,
        string invoiceNumber,
        string invoiceVoucher,
        Guid cOAId,
        Guid customerId,
        DateTime dueDate,
        DateTime invoiceDate,
        int? paymentTerm,
        decimal totalAmount,
        decimal tax,
        decimal discount,
        string note,
        string currency)
    {
        Id = id;
        InvoicePaymentId = invoicePaymentId;
        InvoiceNumber = invoiceNumber;
        InvoiceVoucher = invoiceVoucher;
        COAId = cOAId;
        InvoiceDate = invoiceDate;
        PaymentTerm = paymentTerm;
        CustomerId = customerId;
        DueDate = dueDate;
        TotalAmount = totalAmount;
        Tax = tax;
        Discount = discount;
        Note = note;
        Currency = currency;
    }
    #endregion

}
