using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;

namespace dhanman.money.Application.Features.Customers.Commands.CreateCustomer;

public sealed class CreateCustomerCommand : ICommand<Result<EntityCreatedResponse>>
{
    #region Properties
    public Guid CustomerId { get; }

    public Guid ClientId { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Email { get; }

    public string PhoneNumber { get; }

    public string City { get; }
    #endregion

    #region Constructors
    public CreateCustomerCommand(Guid customerId, Guid clientId, string firstName, string lastName, string email, string phoneNumber, string city)
    {
        CustomerId = customerId;
        ClientId = clientId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        City = city;
    }
    #endregion

}