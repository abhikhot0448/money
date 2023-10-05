using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Contracts.Invoice;
using dhanman.money.Application.Features.Invoice.Events;
using dhanman.money.Domain.Abstractions;
using dhanman.money.Domain.Entities.InvoiceDetails;
using dhanman.money.Domain.Entities.InvoiceHeaders;
using MediatR;

namespace dhanman.money.Application.Features.Invoice.Commands.CreateInvoice;

public class CreateInvoiceCommandHandler : ICommandHandler<CreateInvoiceCommand, Result<EntityCreatedResponse>>
{
    #region Properties
    private readonly IInvoiceHeaderRepository _invoiceHeaderRepository;
    private readonly IInvoiceDetailRepository _invoiceDetailRepository;
    private readonly IMediator _mediator;
    #endregion

    #region Constructors
    public CreateInvoiceCommandHandler(IInvoiceHeaderRepository invoiceHeaderRepository, IInvoiceDetailRepository invoiceDetailRepository, IMediator mediator)
    {
        _invoiceHeaderRepository = invoiceHeaderRepository;
        _invoiceDetailRepository = invoiceDetailRepository;
        _mediator = mediator;
    }
    #endregion

    #region Methodes
    public async Task<Result<EntityCreatedResponse>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {

        var invoiceHeader = GetInvoiceHeaderEntity(request);
        _invoiceHeaderRepository.Insert(invoiceHeader);

        foreach (var item in request.Lines)
        {
            var invoiceDetail = GetInvoiceDetailEntity(item, request.InvoiceId);
            _invoiceDetailRepository.Insert(invoiceDetail);
        }

        await _mediator.Publish(new InvoiceCreatedEvent(invoiceHeader.Id), cancellationToken);
        return Result.Success(new EntityCreatedResponse(invoiceHeader.Id));

    }

    private InvoiceDetail GetInvoiceDetailEntity(InvoiceLine line, Guid InvoiceId)
    {
        return new InvoiceDetail(Guid.NewGuid(), InvoiceId, line.Name, line.Description, line.Price, line.Quantity, line.Amount);
    }

    private InvoiceHeader GetInvoiceHeaderEntity(CreateInvoiceCommand request)
    {
        return new InvoiceHeader(
            request.InvoiceId, request.COAId, request.ClientId, request.InvoiceId,
            request.InvoiceNumber, request.DueDate, request.InvoiceDate, request.InvoiceId,
            request.CustomerId, request.InvoiceVoucher, request.PaymentTerm, request.TotalAmount,
            request.Tax, request.Discount, request.Note, request.Currency);
    }

    #endregion

}
