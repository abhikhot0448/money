using dhanman.money.Domain.Abstractions;
using FluentValidation;

namespace dhanman.money.Application.Features.InvoiceStatuses.Commands.CreateInvoiceStatus;

public class CreateInvoiceStatusCommandValidator : AbstractValidator<CreateInvoiceStatusCommand>
{
    #region Constructors

    public CreateInvoiceStatusCommandValidator(IInvoiceStatusRepository invoiceStatusRepository)
    {
        RuleFor(c => c.Name).MustAsync(async (name, _) =>
        {
            return !string.IsNullOrEmpty(name);
        }).WithMessage("The Name is required");

    }

    #endregion
}
