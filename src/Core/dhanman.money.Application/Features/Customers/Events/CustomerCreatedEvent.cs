using dhanman.money.Application.Abstractions.Messaging;

namespace dhanman.money.Application.Features.Customers.Events;


public sealed class CustomerCreatedEvent : IEvent
{
    #region Properties
    public Guid CustomerId { get; }

    #endregion

    #region Constructors
    public CustomerCreatedEvent(Guid customerId) => CustomerId = customerId;

    #endregion

}