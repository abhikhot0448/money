using FluentValidation;

namespace dhanman.money.Application.Features.InvoicePayments.Commands;

public class CreateInvoicePaymentCommandValidator : AbstractValidator<CreateInvoicePaymentCommand>
{
    #region Constructor

    public CreateInvoicePaymentCommandValidator()
    {
        RuleFor(c => c.Amount).MustAsync(async (amount, _) =>
        {
            return amount >= 0m;
        }).WithMessage("The total amount must be Positive");
    }

    #endregion
}
