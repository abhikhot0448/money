using Dhanman.Money.Application.Abstractions.Messaging;

namespace Dhanman.Money.Application.Features.Customers.Events;


public sealed class CustomerCreatedEvent : IEvent
{
    #region Properties
    public Guid CustomerId { get; }

    #endregion

    #region Constructors
    public CustomerCreatedEvent(Guid customerId) => CustomerId = customerId;

    #endregion

}