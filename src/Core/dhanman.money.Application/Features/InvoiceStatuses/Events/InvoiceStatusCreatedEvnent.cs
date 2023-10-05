using dhanman.money.Application.Abstractions.Messaging;

namespace dhanman.money.Application.Features.InvoiceStatuses.Events;

public class InvoiceStatusCreatedEvnent : IEvent
{
    #region Properties
    public Guid InvoiceStatusId { get; }
    #endregion

    #region Constructors
    public InvoiceStatusCreatedEvnent(Guid invioceStatusId) => InvoiceStatusId = invioceStatusId;
    #endregion

}
