using B2aTech.CrossCuttingConcern.Core.Abstractions;
using B2aTech.CrossCuttingConcern.Core.Primitives;

namespace dhanman.money.Domain.Entities.InvoiceHeaders;

public class InvoiceHeader : Entity, IAuditableEntity, ISoftDeletableEntity
{
    #region Properties
    public Guid ClientId { get; private set; }
    public Guid CustomerId { get; private set; }
    public string Currency { get; private set; }
    public Guid COAId { get; private set; }
    public string InvoiceNumber { get; private set; }
    public string InvoiceVoucher { get; private set; }
    public DateTime InvoiceDate { get; private set; }
    public int? PaymentTerm { get; private set; }
    public Guid InvoiceStatusId { get; private set; }
    public Guid InvoicePaymentId { get; private set; }
    public DateTime DueDate { get; private set; }
    public decimal TotalAmount { get; private set; }
    public decimal Tax { get; private set; }
    public decimal Discount { get; private set; }
    public string Note { get; private set; }
    public Guid UserId { get; set; }
    public DateTime CreatedOnUtc { get; }
    public Guid CreatedBy { get; }
    public Guid? ModifiedBy { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }
    public bool IsDeleted { get; }
    #endregion

    #region Constructors
    public InvoiceHeader() { }

    public InvoiceHeader(Guid id, Guid cOAId, Guid clientId, Guid invoicePaymentId, string invoiceNumber, DateTime dueDate, DateTime invoiceDate, Guid invoiceStatusId, Guid customerId, string invoiceVoucher, int? paymentTerm, decimal totalAmount, decimal tax, decimal discount, string note, string currency)
    {
        Id = id;
        ClientId = clientId;
        CustomerId = customerId;
        COAId = cOAId;
        InvoiceNumber = invoiceNumber;
        InvoiceVoucher = invoiceVoucher;
        InvoiceDate = invoiceDate;
        PaymentTerm = paymentTerm;
        InvoiceStatusId = invoiceStatusId;
        InvoicePaymentId = invoicePaymentId;
        DueDate = dueDate;
        TotalAmount = totalAmount;
        Tax = tax;
        Discount = discount;
        Note = note;
        Currency = currency;
        CreatedBy = clientId;
        CreatedOnUtc = DateTime.UtcNow;
    }
    #endregion

}