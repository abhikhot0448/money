﻿using dhanman.money.Domain;
using FluentValidation;

namespace dhanman.money.Application.Features.Authentication.Commands.Login;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginCommandValidator"/> class.
    /// </summary>
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithErrorCode(Errors.Email.NullOrEmpty);

        RuleFor(x => x.Password).NotEmpty().WithErrorCode(Errors.Password.NullOrEmpty);
    }
    #endregion
   
}
