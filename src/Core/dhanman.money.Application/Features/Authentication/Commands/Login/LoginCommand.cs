using B2aTech.CrossCuttingConcern.Core.Result;
using Dhanman.Money.Application.Abstractions.Messaging;
using Dhanman.Money.Application.Contracts.Authentication;

namespace Dhanman.Money.Application.Features.Authentication.Commands.Login;

public sealed class LoginCommand : ICommand<Result<TokenResponse>>
{
    #region Properties
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginCommand"/> class.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="password">The password.</param>
    /// <summary>
    /// Gets the email.
    /// </summary>
    public string Email { get; }

    /// <summary>
    /// Gets the password.
    /// </summary>
    public string Password { get; }

    #endregion

    #region Constructors
    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
    #endregion
}
