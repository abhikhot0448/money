using B2aTech.CrossCuttingConcern.Core.Result;
using Dhanman.Money.Application.Abstractions.Cryptography;
using Dhanman.Money.Application.Abstractions.Messaging;
using Dhanman.Money.Application.Contracts.Common;
using Dhanman.Money.Domain.Abstractions;
using Dhanman.Money.Domain.Entities.Customers;
using Dhanman.Money.Domain.Entities.Users;

namespace Dhanman.Money.Application.Features.Authentication.Commands.Register;

internal class RegisterCommandHandler : ICommandHandler<RegisterCommand, Result<EntityCreatedResponse>>
{

    #region Properties
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    #endregion

    #region Constructors
    public RegisterCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    #endregion

    #region Methodes
    public async Task<Result<EntityCreatedResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new User(Guid.NewGuid(),
                            FirstName.Create(request.FirstName).Value(),
                            LastName.Create(request.LastName).Value(),
                            Email.Create(request.Email).Value()
                            , _passwordHasher.HashPassword(Password.Create(request.Password).Value()));

        _userRepository.Insert(user);

        //await _mediator.Publish(new CustomerCreatedEvent(customer.Id), cancellationToken);

        return Result.Success(new EntityCreatedResponse(user.Id));
    }
    #endregion

}
