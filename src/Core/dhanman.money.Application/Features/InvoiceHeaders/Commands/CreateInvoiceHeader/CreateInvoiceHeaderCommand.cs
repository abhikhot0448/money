using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;

namespace dhanman.money.Application.Features.InvoiceHeaders.Commands.CreateInvoiceHeader;

public class CreateInvoiceHeaderCommand : ICommand<Result<EntityCreatedResponse>>
{
    #region Properties
    public Guid InvoiceHeaderId { get; private set; }
    public Guid COAId { get; private set; }
    public string InvoiceNumber { get; private set; }
    public string InvoiceVoucher { get; private set; }
    public DateTime InvoiceDate { get; private set; }
    public int PaymentTerm { get; private set; }
    public Guid InvoiceStatusId { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid InvoicePaymentId { get; private set; }
    public DateTime DueDate { get; private set; }
    public decimal TotalAmount { get; private set; }
    public string Currency { get; private set; }
    public decimal Tax { get; private set; }
    public decimal Discount { get; private set; }
    public string Note { get; private set; }
    public Guid ClientId { get; private set; }
    public Guid UserId { get; set; }
    public DateTime CreatedOnUtc { get; }
    #endregion

    #region Constructors
    public CreateInvoiceHeaderCommand(Guid invoiceHeaderId, Guid cOAId, Guid clientId, string invoiceNumber, string invoiceVoucher, int paymentTerm, Guid invoicePaymentId, Guid invoiceStatusId, Guid customerId, decimal totalAmount, decimal tax, decimal discount, string note, string currency, DateTime invoiceDate, DateTime dueDate)
    {
        InvoiceHeaderId = invoiceHeaderId;
        COAId = cOAId;
        ClientId = clientId;
        InvoiceNumber = invoiceNumber;
        InvoiceVoucher = invoiceVoucher;
        PaymentTerm = paymentTerm;
        InvoiceStatusId = invoiceStatusId;
        InvoicePaymentId = invoicePaymentId;
        CustomerId = customerId;
        TotalAmount = totalAmount;
        Tax = tax;
        Discount = discount;
        Note = note;
        Currency = currency;
        InvoiceDate = invoiceDate;
        DueDate = dueDate;
    }

    #endregion

}
