using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Features.Customers.Events;
using dhanman.money.Domain.Abstractions;
using dhanman.money.Domain.Exceptions;
using MediatR;

namespace dhanman.money.Application.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand, Result<EntityUpdatedResponse>>
{

    #region Properties

    private readonly ICustomerRepository _customerRepository;
    private readonly IMediator _mediator;
    #endregion

    #region Constructor

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMediator mediator, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _mediator = mediator;

    }
    #endregion

    #region Methods

    public async Task<Result<EntityUpdatedResponse>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

        if (customer == null)
        {
            throw new CustomerNotFoundException(request.CustomerId);
        }

        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.Email = request.Email;
        customer.City = request.City;
        customer.PhoneNumber = request.PhoneNumber;

        _customerRepository.Update(customer);

        await _mediator.Publish(new CustomerUpdatedEvent(customer.Id), cancellationToken);

        return Result.Success(new EntityUpdatedResponse(customer.Id));
    }
    #endregion

}
