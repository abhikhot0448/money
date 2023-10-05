using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Features.InvoicePayments.Events;
using dhanman.money.Domain.Abstractions;
using dhanman.money.Domain.Entities.InvoicePayments;
using MediatR;

namespace dhanman.money.Application.Features.InvoicePayments.Commands;

public class CreateInvoicePaymentCommandHandler : ICommandHandler<CreateInvoicePaymentCommand, Result<EntityCreatedResponse>>
{
    #region Properties
    private readonly IInvoicePaymentRepository _invoicePaymentRepository;
    private readonly IMediator _mediator;
    #endregion

    #region Constructors
    public CreateInvoicePaymentCommandHandler(IInvoicePaymentRepository invoicePaymentRepository, IMediator mediator)
    {
        _invoicePaymentRepository = invoicePaymentRepository;
        _mediator = mediator;
    }
    #endregion

    #region Methodes
    public async Task<Result<EntityCreatedResponse>> Handle(CreateInvoicePaymentCommand request, CancellationToken cancellationToken)
    {
        var invoicePayment = new InvoicePayment(request.InvoicePaymentId, request.ClientId, request.Amount, request.InvoiceHeaderId, request.TransactionId, request.COAId, request.ClientId);
        _invoicePaymentRepository.Insert(invoicePayment);
        await _mediator.Publish(new InvoicePaymentCreatedEvent(invoicePayment.Id), cancellationToken);
        return Result.Success(new EntityCreatedResponse(invoicePayment.Id));
    }
    #endregion

}
