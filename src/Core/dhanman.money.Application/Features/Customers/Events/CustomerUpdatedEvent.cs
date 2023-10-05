using Dhanman.Money.Application.Abstractions.Messaging;

namespace Dhanman.Money.Application.Features.Customers.Events;

public sealed class CustomerUpdatedEvent : IEvent
{
    #region Constructor

    public CustomerUpdatedEvent(Guid customerId) => CustomerId = customerId;

    #endregion

    #region Properties

    public Guid CustomerId { get; }
    #endregion

}
