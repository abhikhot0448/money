using dhanman.money.Application.Abstractions.Messaging;

namespace dhanman.money.Application.Features.Customers.Events;

public sealed class CustomerUpdatedEvent : IEvent
{
    #region Constructor

    public CustomerUpdatedEvent(Guid customerId) => CustomerId = customerId;

    #endregion

    #region Properties

    public Guid CustomerId { get; }
    #endregion

}
