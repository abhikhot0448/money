using dhanman.money.Domain.Abstractions;
using FluentValidation;

namespace dhanman.money.Application.Features.InvoiceHeaders.Commands.CreateInvoiceHeader;

public class CreateInvoiceHeaderCommandValidator : AbstractValidator<CreateInvoiceHeaderCommand>
{
    #region Constructor

    public CreateInvoiceHeaderCommandValidator(IInvoiceHeaderRepository invoiceHeaderRepository)
    {
        RuleFor(c => c.Currency).MustAsync(async (currency, _) =>
        {
            return !string.IsNullOrEmpty(currency);
        }).WithMessage("The currency is required");

        RuleFor(c => c.TotalAmount).MustAsync(async (totalAmount, _) =>
        {
            return totalAmount >= 0m;
        }).WithMessage("The total amount must be Positive");

        RuleFor(c => c.InvoiceNumber).MustAsync(async (invoiceNumber, _) =>
        {
            return !string.IsNullOrEmpty(invoiceNumber);
        }).WithMessage("The invoice number is required");
    }

    #endregion

}
