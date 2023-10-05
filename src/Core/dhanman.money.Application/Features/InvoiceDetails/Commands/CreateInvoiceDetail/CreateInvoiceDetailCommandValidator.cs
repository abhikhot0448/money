using dhanman.money.Domain.Abstractions;
using FluentValidation;

namespace dhanman.money.Application.Features.InvoiceDetails.Commands.CreateInvoiceDetail;

public class CreateInvoiceDetailCommandValidator : AbstractValidator<CreateInvoiceDetailCommand>
{
    #region Constructor

    public CreateInvoiceDetailCommandValidator(IInvoiceDetailRepository invoiceDetailRepository)
    {
        RuleFor(c => c.Name).MustAsync(async (name, _) =>
        {
            return !string.IsNullOrEmpty(name);
        }).WithMessage("The name is required");

        RuleFor(c => c.Amount).MustAsync(async (amount, _) =>
        {
            return amount >= 0m;
        }).WithMessage("The amount must be Positive value");
    }
    #endregion

}