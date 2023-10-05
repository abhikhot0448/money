using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Features.InvoiceDetails.Events;
using dhanman.money.Domain.Abstractions;
using dhanman.money.Domain.Entities.InvoiceDetails;
using MediatR;

namespace dhanman.money.Application.Features.InvoiceDetails.Commands.CreateInvoiceDetail;

public class CreateInvoiceDetailCommandHandler : ICommandHandler<CreateInvoiceDetailCommand, Result<EntityCreatedResponse>>
{
    #region Properties
    private readonly IInvoiceDetailRepository _invoiceDetailRepository;
    private readonly IMediator _mediator;
    #endregion

    #region Constructors
    public CreateInvoiceDetailCommandHandler(IInvoiceDetailRepository invoiceDetailRepository,
   IMediator mediator)
    {
        _invoiceDetailRepository = invoiceDetailRepository;
        _mediator = mediator;

    }
    #endregion

    #region Methodes
    public async Task<Result<EntityCreatedResponse>> Handle(CreateInvoiceDetailCommand request, CancellationToken cancellationToken)
    {
        var invoiceDetail = new InvoiceDetail(request.InvoiceDetailId, request.InvoiceHeaderId, request.Name, request.Description, request.Price, request.Quantity, request.Amount);

        _invoiceDetailRepository.Insert(invoiceDetail);

        await _mediator.Publish(new InvoiceDetailCreatedEvent(invoiceDetail.Id), cancellationToken);

        return Result.Success(new EntityCreatedResponse(invoiceDetail.Id));
    }
    #endregion

}
