using dhanman.money.Application.Abstractions.Messaging;

namespace dhanman.money.Application.Features.InvoiceDetails.Events;

public class InvoiceDetailCreatedEvent : IEvent
{
    #region Properties
    public Guid InvoiceDetailId { get; }
    #endregion

    #region Constructors
    public InvoiceDetailCreatedEvent(Guid invoiceDetailId) => InvoiceDetailId = invoiceDetailId;
    #endregion

}
