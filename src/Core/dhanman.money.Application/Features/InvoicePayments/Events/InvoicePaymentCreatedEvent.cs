using dhanman.money.Application.Abstractions.Messaging;

namespace dhanman.money.Application.Features.InvoicePayments.Events;

public class InvoicePaymentCreatedEvent : IEvent
{
    #region Properties
    public Guid InvoicePaymentId { get; }
    #endregion

    #region Constructors
    public InvoicePaymentCreatedEvent(Guid invoicePaymentId) => InvoicePaymentId = invoicePaymentId;
    #endregion

}
