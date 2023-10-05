using dhanman.money.Application.Abstractions.Messaging;

namespace dhanman.money.Application.Features.InvoiceHeaders.Events;

public class InvoiceHeaderCreatedEvent : IEvent
{
    #region Properties
    public Guid InvoiceHeaderId { get; }
    #endregion

    #region Constructors
    public InvoiceHeaderCreatedEvent(Guid invoiceHeaderId) => InvoiceHeaderId = invoiceHeaderId;
    #endregion

}