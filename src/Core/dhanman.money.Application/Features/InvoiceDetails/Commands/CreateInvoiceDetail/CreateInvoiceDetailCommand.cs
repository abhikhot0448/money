using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;

namespace dhanman.money.Application.Features.InvoiceDetails.Commands.CreateInvoiceDetail;

public class CreateInvoiceDetailCommand : ICommand<Result<EntityCreatedResponse>>
{
    #region Properties
    public Guid InvoiceHeaderId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public decimal Amount { get; private set; }
    public Guid InvoiceDetailId { get; }
    #endregion

    #region Constructors
    public CreateInvoiceDetailCommand(Guid invoiceDetailId, Guid invoiceHeaderId, string name, string description, decimal price, int quantity, decimal amount)
    {
        InvoiceDetailId = invoiceDetailId;
        InvoiceHeaderId = invoiceHeaderId;
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        Amount = amount;
    }
    #endregion

}
