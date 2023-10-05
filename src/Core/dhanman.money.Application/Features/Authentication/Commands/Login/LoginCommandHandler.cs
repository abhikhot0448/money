using B2aTech.CrossCuttingConcern.Core.Result;
using Dhanman.Money.Application.Abstractions.Authentication;
using Dhanman.Money.Application.Abstractions.Messaging;
using Dhanman.Money.Application.Contracts.Authentication;
using Dhanman.Money.Domain;
using Dhanman.Money.Domain.Abstractions;
using Dhanman.Money.Domain.Entities.Users.Services;

namespace Dhanman.Money.Application.Features.Authentication.Commands.Login;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, Result<TokenResponse>>
{
    #region Properties
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashChecker _passwordHashChecker;
    private readonly IJwtProvider _jwtProvider;

    #endregion

    #region Constructors
    public LoginCommandHandler(IUserRepository userRepository, IPasswordHashChecker passwordHashChecker, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _passwordHashChecker = passwordHashChecker;
    }
    #endregion

    #region Methodes

    public async Task<Result<TokenResponse>> Handle(LoginCommand request, CancellationToken cancellationToken) =>
            await Result.Success(request)
                .Bind(
                    command => _userRepository.GetByEmailAsync(command.Email),
                    Errors.Authentication.InvalidEmailOrPassword)
                .Ensure(
                    user => user.VerifyPasswordHash(request.Password, _passwordHashChecker),
                    Errors.Authentication.InvalidEmailOrPassword)
                .Bind(user => _jwtProvider.CreateAsync(user));
    #endregion

}