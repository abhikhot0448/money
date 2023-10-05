using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Contracts.Invoice;

namespace dhanman.money.Application.Features.Invoice.Commands.CreateInvoice;

public class CreateInvoiceCommand : ICommand<Result<EntityCreatedResponse>>
{
    #region Properties
    public Guid InvoiceId { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid ClientId { get; private set; }
    public Guid COAId { get; private set; }
    public string InvoiceNumber { get; private set; }
    public string InvoiceVoucher { get; private set; }
    public DateTime InvoiceDate { get; private set; }
    public int? PaymentTerm { get; private set; }
    public DateTime DueDate { get; private set; }
    public decimal TotalAmount { get; private set; }
    public string Currency { get; private set; }
    public decimal Tax { get; private set; }
    public decimal Discount { get; private set; }
    public string Note { get; private set; }
    public List<InvoiceLine> Lines { get; private set; }
    #endregion

    #region Constructors
    public CreateInvoiceCommand() { }

    public CreateInvoiceCommand(Guid id, Guid customerId, Guid clientId, string invoiceNumber,
        string invoiceVoucher, DateTime invoiceDate, int? paymentTerm, DateTime dueDate, decimal totalAmount, string currency,
        decimal tax, decimal discount, string note, List<InvoiceLine> lines)
    {
        InvoiceId = id;
        CustomerId = customerId;
        ClientId = clientId;
        InvoiceNumber = invoiceNumber;
        InvoiceVoucher = invoiceVoucher;
        InvoiceDate = invoiceDate;
        PaymentTerm = paymentTerm;
        DueDate = dueDate;
        TotalAmount = totalAmount;
        Currency = currency;
        Tax = tax;
        Discount = discount;
        Note = note;
        Lines = lines;
    }
    #endregion

}
