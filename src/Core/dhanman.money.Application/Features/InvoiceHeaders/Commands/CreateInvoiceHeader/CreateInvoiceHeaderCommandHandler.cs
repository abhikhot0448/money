using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Features.InvoiceHeaders.Events;
using dhanman.money.Domain.Abstractions;
using dhanman.money.Domain.Entities.InvoiceHeaders;
using MediatR;

namespace dhanman.money.Application.Features.InvoiceHeaders.Commands.CreateInvoiceHeader;

public class CreateInvoiceHeaderCommandHandler : ICommandHandler<CreateInvoiceHeaderCommand, Result<EntityCreatedResponse>>
{
    #region Properties
    private readonly IInvoiceHeaderRepository _invoiceHeaderRepository;
    private readonly IMediator _mediator;
    #endregion


    #region Constructors
    public CreateInvoiceHeaderCommandHandler(
       IInvoiceHeaderRepository invoiceHeaderRepository,
       IMediator mediator)
    {
        _invoiceHeaderRepository = invoiceHeaderRepository;
        _mediator = mediator;
    }
    #endregion

    #region Methods
    public async Task<Result<EntityCreatedResponse>> Handle(CreateInvoiceHeaderCommand request, CancellationToken cancellationToken)
    {
        var invoiceHeader = new InvoiceHeader(request.InvoiceHeaderId, request.COAId, request.ClientId, request.InvoicePaymentId, request.InvoiceNumber,
                                              request.DueDate, request.InvoiceDate, request.InvoiceStatusId, request.CustomerId, request.InvoiceVoucher,
                                              request.PaymentTerm, request.TotalAmount, request.Tax, request.Discount, request.Note, request.Currency);

        _invoiceHeaderRepository.Insert(invoiceHeader);

        await _mediator.Publish(new InvoiceHeaderCreatedEvent(invoiceHeader.Id), cancellationToken);

        return Result.Success(new EntityCreatedResponse(invoiceHeader.Id));
    }

    #endregion

}