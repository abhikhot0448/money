using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Features.Customers.Events;
using dhanman.money.Domain.Abstractions;
using dhanman.money.Domain.Entities.Customers;
using MediatR;

namespace dhanman.money.Application.Features.Customers.Commands.CreateCustomer;

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
