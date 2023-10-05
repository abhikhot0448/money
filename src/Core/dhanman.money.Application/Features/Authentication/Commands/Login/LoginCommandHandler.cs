using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Authentication;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Authentication;
using dhanman.money.Domain;
using dhanman.money.Domain.Abstractions;
using dhanman.money.Domain.Entities.Users.Services;

namespace dhanman.money.Application.Features.Authentication.Commands.Login;

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