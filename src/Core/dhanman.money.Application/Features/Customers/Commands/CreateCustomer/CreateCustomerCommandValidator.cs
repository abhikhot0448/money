using dhanman.money.Domain.Abstractions;
using FluentValidation;

namespace dhanman.money.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
  
    #region Constructors
    public CreateCustomerCommandValidator(ICustomerRepository customerRepository)
    {
        RuleFor(c => c.FirstName).MustAsync(async (firstName, _) =>
        {
            return !string.IsNullOrEmpty(firstName);
        }).WithMessage("The First Name is required");

        RuleFor(c => c.LastName).MustAsync(async (lastName, _) =>
        {
            return !string.IsNullOrEmpty(lastName);
        }).WithMessage("The Last Name is required");

        RuleFor(c => c.Email).MustAsync(async (email, _) =>
        {
            return await customerRepository.IsEmailUniqueAsync(email);
        }).WithMessage("The email must be unique");

        RuleFor(c => c.PhoneNumber).MustAsync(async (phoneNumber, _) =>
        {
            return await customerRepository.IsPhoneNumberUniqueAsync(phoneNumber);
        }).WithMessage("The phone number must be unique");
    }
    #endregion

}
