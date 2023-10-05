using dhanman.money.Application.Abstractions.Messaging;

namespace dhanman.money.Application.Features.Invoice.Events;

public class InvoiceCreatedEvent : IEvent
{
    public Guid InvoiceHeaderId;
    public InvoiceCreatedEvent(Guid id) => InvoiceHeaderId = id;

}
