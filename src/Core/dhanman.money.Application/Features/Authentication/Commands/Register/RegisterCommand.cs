using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;

namespace dhanman.money.Application.Features.Authentication.Commands.Register;

public sealed class RegisterCommand : ICommand<Result<EntityCreatedResponse>>
{
    #region Properties
   
    /// <summary>
    /// Gets the first name.
    /// </summary>
    public string FirstName { get; }

    /// <summary>
    /// Gets the last name.
    /// </summary>
    public string LastName { get; }

    /// <summary>
    /// Gets the email.
    /// </summary>
    public string Email { get; }

    /// <summary>
    /// Gets the password.
    /// </summary>
    public string Password { get; }

    /// <summary>
    /// Gets the confirmed password.
    /// </summary>
    public string ConfirmPassword { get; }
    #endregion

    #region Constructors
    public RegisterCommand(string firstName, string lastName, string email, string password, string confirmPassword)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
    }
    #endregion

}
