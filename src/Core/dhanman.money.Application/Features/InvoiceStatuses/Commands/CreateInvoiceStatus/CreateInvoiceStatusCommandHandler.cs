using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Features.InvoiceStatuses.Events;
using dhanman.money.Domain.Abstractions;
using dhanman.money.Domain.Entities.InvoiceStatuses;
using MediatR;

namespace dhanman.money.Application.Features.InvoiceStatuses.Commands.CreateInvoiceStatus;

public class CreateInvoiceStatusCommandHandler : ICommandHandler<CreateInvoiceStatusCommand, Result<EntityCreatedResponse>>
{
    #region Properties
    private readonly IInvoiceStatusRepository _invoiceStatusRepository;
    private readonly IMediator _mediator;

    #endregion

    #region Constructors
    public CreateInvoiceStatusCommandHandler(
      IInvoiceStatusRepository invoiceStatusRepository,
      IMediator mediator)
    {
        _invoiceStatusRepository = invoiceStatusRepository;
        _mediator = mediator;
    }
    #endregion

    #region Methods
    public async Task<Result<EntityCreatedResponse>> Handle(CreateInvoiceStatusCommand request, CancellationToken cancellationToken)
    {
        var invoiceStatuse = new InvoiceStatus(request.InvoiceStatusId, request.Name, request.ClientId, request.ClientId);

        _invoiceStatusRepository.Insert(invoiceStatuse);

        await _mediator.Publish(new InvoiceStatusCreatedEvnent(invoiceStatuse.Id), cancellationToken);

        return Result.Success(new EntityCreatedResponse(invoiceStatuse.Id));
    }
    #endregion
}
