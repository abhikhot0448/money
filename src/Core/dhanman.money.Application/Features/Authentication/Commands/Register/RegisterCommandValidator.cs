﻿using dhanman.money.Domain;
using FluentValidation;

namespace dhanman.money.Application.Features.Authentication.Commands.Register;

public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{

    #region Constructors
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithErrorCode(Errors.FirstName.NullOrEmpty);

        RuleFor(x => x.LastName).NotEmpty().WithErrorCode(Errors.LastName.NullOrEmpty);

        RuleFor(x => x.Email).NotEmpty().WithErrorCode(Errors.Email.NullOrEmpty);

        RuleFor(x => x.Password).NotEmpty().WithErrorCode(Errors.Password.NullOrEmpty);

        RuleFor(x => x.ConfirmPassword).NotEmpty().WithErrorCode(Errors.Password.NullOrEmpty);

        RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithErrorCode(Errors.Authentication.PasswordsDoNotMatch);
    }
    #endregion

}
