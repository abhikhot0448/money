using dhanman.money.Domain.Abstractions;
using FluentValidation;

namespace dhanman.money.Application.Features.Invoice.Commands.CreateInvoice;

public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
{
    #region Constructor

    public CreateInvoiceCommandValidator(IInvoiceHeaderRepository invoiceHeaderRepository, IInvoiceDetailRepository invoiceDetailRepository)
    {
        RuleFor(c => c.Currency).MustAsync(async (currency, _) =>
        {
            return !string.IsNullOrEmpty(currency);
        }).WithMessage("The currency is required");

        RuleFor(c => c.TotalAmount).MustAsync(async (totalAmount, _) =>
        {
            return totalAmount >= 0m;
        }).WithMessage("The total amount must be positive");

        RuleFor(c => c.InvoiceNumber).MustAsync(async (invoiceNumber, _) =>
        {
            return !string.IsNullOrEmpty(invoiceNumber);
        }).WithMessage("The invoice number is required");

        RuleFor(c => c.InvoiceNumber).MustAsync(async (invoiceNumber, _) =>
        {
            return await invoiceHeaderRepository.IsInvoiceNumberUniqueAsync(invoiceNumber);
        }).WithMessage("The invoice number must be unique");

    }

    #endregion
}
