using B2aTech.CrossCuttingConcern.Core.Result;
using Dhanman.Money.Application.Abstractions.Messaging;
using Dhanman.Money.Application.Contracts.Common;
using Dhanman.Money.Application.Features.Customers.Events;
using Dhanman.Money.Domain.Abstractions;
using Dhanman.Money.Domain.Entities.Customers;
using MediatR;

namespace Dhanman.Money.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Result<EntityCreatedResponse>>
{
    #region Properties
    private readonly ICustomerRepository _customerRepository;
    private readonly IMediator _mediator;
    #endregion

    #region Constructors
    public CreateCustomerCommandHandler(
       ICustomerRepository customerRepository,
       IMediator mediator)
    {
        _customerRepository = customerRepository;
        _mediator = mediator;
    }
    #endregion

    #region Methods
    public async Task<Result<EntityCreatedResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(request.CustomerId, request.ClientId, request.FirstName, request.LastName, request.Email, request.PhoneNumber, request.City, request.ClientId);

        _customerRepository.Insert(customer);

        await _mediator.Publish(new CustomerCreatedEvent(customer.Id), cancellationToken);

        return Result.Success(new EntityCreatedResponse(customer.Id));
    }
    #endregion

}
