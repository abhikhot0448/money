using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Api.Contracts;
using dhanman.money.Api.Infrastructure;
using dhanman.money.Application.Contracts.Common;
using dhanman.money.Application.Contracts.Invoice;
using dhanman.money.Application.Contracts.InvoiceDetails;
using dhanman.money.Application.Contracts.InvoiceHeaders;
using dhanman.money.Application.Contracts.InvoicePayment;
using dhanman.money.Application.Contracts.InvoiceStatuses;
using dhanman.money.Application.Features.Invoice.Commands.CreateInvoice;
using dhanman.money.Application.Features.Invoice.Queries;
using dhanman.money.Application.Features.InvoiceDetails.Commands.CreateInvoiceDetail;
using dhanman.money.Application.Features.InvoiceDetails.Queries;
using dhanman.money.Application.Features.InvoiceHeaders.Commands.CreateInvoiceHeader;
using dhanman.money.Application.Features.InvoiceHeaders.Queries;
using dhanman.money.Application.Features.InvoiceHeaders.Quries;
using dhanman.money.Application.Features.InvoicePayments.Commands;
using dhanman.money.Application.Features.InvoicePayments.Queries;
using dhanman.money.Application.Features.InvoiceStatuses.Commands.CreateInvoiceStatus;
using dhanman.money.Application.Features.InvoiceStatuses.Queries;
using dhanman.money.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dhanman.money.Api.Controllers;

public class InvoicesController : ApiController
{
    public InvoicesController(IMediator mediator)
           : base(mediator)
    {

    }

    #region Invoices

    [HttpPost(ApiRoutes.Invoices.CreateInvoice)]
    [ProducesResponseType(typeof(EntityCreatedResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceRequest? request) =>
        await Result.Create(request,Errors.General.BadRequest)
        .Map(value => new CreateInvoiceCommand(
            Guid.NewGuid(),
            value.CustomerId,
            value.ClientId,
            value.InvoiceNumber,
            value.InvoiceVoucher,
            value.InvoiceDate,
            value.PaymentTerm,
            value.DueDate,
            value.TotalAmount,
            value.Currency,
            value.Tax,
            value.Discount,
            value.Note,
            value.Lines
            ))
         .Bind(command => Mediator.Send(command))
               .Match(Ok, BadRequest);


    [HttpGet(ApiRoutes.Invoices.GetAllInvoices)]
    [ProducesResponseType(typeof(InvoiceListResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllInvoices(Guid clientId) =>
      await Result.Success(new GetAllInvoicesQuery(clientId))
      .Bind(query => Mediator.Send(query))
      .Match(Ok, NotFound);

    #endregion

    #region Invoice Status

    [HttpGet(ApiRoutes.InvoiceStatus.GetInvoiceStatusesById)]
    [ProducesResponseType(typeof(InvoiceStatusResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetInvoiceStatuseById(Guid id) =>
    await Result.Success(new GetInvoiceStatusByIdQuery(id))
        .Bind(query => Mediator.Send(query))
        .Match(Ok, NotFound);

    [HttpPost(ApiRoutes.InvoiceStatus.GetInvoiceStatuses)]
    [ProducesResponseType(typeof(EntityCreatedResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateInvoiceStatuse([FromBody] CreateInvoiceStatusRequest? request) =>
            await Result.Create(request, Errors.General.BadRequest)
                .Map(value => new CreateInvoiceStatusCommand(
                    Guid.NewGuid(),
                    value.ClientId,
                    value.Name))
                .Bind(command => Mediator.Send(command))
               .Match(Ok, BadRequest);
    #endregion

    #region Invoice Details
    [HttpGet(ApiRoutes.InvoiceDetails.GetInvoiceDetails)]
    [ProducesResponseType(typeof(InvoiceDetailListResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllInvoiceDetails() =>
        await Result.Success(new GetAllInvoiceDetailQuery())
        .Bind(query => Mediator.Send(query))
        .Match(Ok, NotFound);

    [HttpGet(ApiRoutes.InvoiceDetails.GetInvoiceDetailsById)]
    [ProducesResponseType(typeof(InvoiceStatusResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetInvoiceDetailsById(Guid id) =>
    await Result.Success(new GetInvoiceDetailByIdQuery(id))
        .Bind(query => Mediator.Send(query))
        .Match(Ok, NotFound);

    [HttpPost(ApiRoutes.InvoiceDetails.CreateInvoiceDetail)]
    [ProducesResponseType(typeof(EntityCreatedResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateInvoiceDetail([FromBody] CreateInvoiceDetailRequest? request) =>
            await Result.Create(request, Errors.General.BadRequest)
                .Map(value => new CreateInvoiceDetailCommand(
                    Guid.NewGuid(),
                    value.InvoiceHeaderId,
                    value.Name,
                    value.Description,
                    value.Price,
                    value.Quantity,
                    value.Amount))
                .Bind(command => Mediator.Send(command))
               .Match(Ok, BadRequest);
    #endregion

    #region Invoice Payment

    [HttpGet(ApiRoutes.InvoicePayments.GetInvoicePaymentsById)]
    [ProducesResponseType(typeof(InvoicePaymentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetInvoicePaymentsById(Guid id) =>
    await Result.Success(new GetInvoicePaymentByIdQuery(id))
        .Bind(query => Mediator.Send(query))
        .Match(Ok, NotFound);

    [HttpPost(ApiRoutes.InvoicePayments.CreateInvoicePayments)]
    [ProducesResponseType(typeof(EntityCreatedResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateInvoicePayment([FromBody] CreateInvoicePaymentRequest? request) =>
           await Result.Create(request, Errors.General.BadRequest)
               .Map(value => new CreateInvoicePaymentCommand(
                   Guid.NewGuid(),
                   value.ClientId,
                   value.Amount,
                   value.InvoiceHeaderId,
                   value.TransactionId,
                   value.COAId))
               .Bind(command => Mediator.Send(command))
              .Match(Ok, BadRequest);
    #endregion

    #region Invoice Header

    [HttpGet(ApiRoutes.InvoiceHeaders.GetInvoiceHeaders)]
    [ProducesResponseType(typeof(InvoiceHeaderListResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllInvoiceHeaderes(Guid clientId) =>
    await Result.Success(new GetAllInvoiceHeadersQuery( clientId))
        .Bind(query => Mediator.Send(query))
        .Match(Ok, NotFound);

     [HttpGet(ApiRoutes.InvoiceHeaders.GetInvoiceHeaderesById)]
    [ProducesResponseType(typeof(InvoiceHeaderResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetInvoiceHeaderesById(Guid id) =>
    await Result.Success(new GetInvoiceHeaderByIdQuery(id))
        .Bind(query => Mediator.Send(query))
        .Match(Ok, NotFound);

    [HttpPost(ApiRoutes.InvoiceHeaders.CreateInvoiceHeaders)]
    [ProducesResponseType(typeof(EntityCreatedResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateInvoiceHeaderes([FromBody] CreateInvoiceHeaderRequest? request) =>
            await Result.Create(request, Errors.General.BadRequest)
                .Map(value => new CreateInvoiceHeaderCommand(
                    Guid.NewGuid(),
                    value.COAId,
                    value.ClientId,
                    value.InvoiceNumber,
                    value.InvoiceVoucher,
                    value.PaymentTerm,
                    value.InvoicePaymentId,
                    value.InvoiceStatusId,
                    value.CustomerId,
                    value.TotalAmount,
                    value.Tax,
                    value.Discount,
                    value.Note,
                    value.Currency,
                    value.InvoiceDate,
                    value.DueDate))
                .Bind(command => Mediator.Send(command))
               .Match(Ok, BadRequest);
    #endregion

}
