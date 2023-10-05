using B2aTech.CrossCuttingConcern.Core.Result;
using Dhanman.Money.Api.Contracts;
using Dhanman.Money.Api.Infrastructure;
using Dhanman.Money.Application.Contracts.Common;
using Dhanman.Money.Application.Contracts.Customers;
using Dhanman.Money.Application.Features.Customers.Commands.CreateCustomer;
using Dhanman.Money.Application.Features.Customers.Commands.UpdateCustomer;
using Dhanman.Money.Application.Features.Customers.Queries;
using Dhanman.Money.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dhanman.Money.Api.Controllers;

public class CustomersController : ApiController
{
    // private readonly IUserIdentifierProvider _userIdentifierProvider;

    public CustomersController(IMediator mediator)
        : base(mediator)
    {
        //_userIdentifierProvider = userIdentifierProvider;
    }

    #region Customer
    //[HasPermission(Permission.IncomeRead)]
    [HttpGet(ApiRoutes.Customers.GetCustomers)]
    [ProducesResponseType(typeof(CustomerListResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllCustomers(Guid clientId) =>
        await Result.Success(new GetAllCustomersQuery(clientId))
        .Bind(query => Mediator.Send(query))
        .Match(Ok, NotFound);

    [HttpGet(ApiRoutes.Customers.GetCustomerById)]
    [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCustomerById(Guid id) =>
            await Result.Success(new GetCustomerByIdQuery(id))
                .Bind(query => Mediator.Send(query))
                .Match(Ok, NotFound);

    [HttpPost(ApiRoutes.Customers.CreateCustomer)]
    [ProducesResponseType(typeof(EntityCreatedResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest? request) =>
            await Result.Create(request, Errors.General.BadRequest)
                .Map(value => new CreateCustomerCommand(
                    Guid.NewGuid(),
                    value.ClientId,
                    value.FirstName,
                    value.LastName,
                    value.Email,
                    value.PhoneNumber,
                    value.City))
                .Bind(command => Mediator.Send(command))
               .Match(Ok, BadRequest);


    [HttpPut(ApiRoutes.Customers.UpdateCustomer)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequest? request)
    {
        var result = await Result.Create(request, Errors.General.BadRequest)
            .Map(value => new UpdateCustomerCommand(
                value.CustomerId,
                value.ClientId,
                value.FirstName,
                value.LastName,
                value.Email,
                value.PhoneNumber,
                value.City))
            .Bind(command => Mediator.Send(command));

        if (result.IsSuccess)
        {
            return NoContent();
        }
        else
        {
            return BadRequest(result.Error);
        }
    }


    #endregion

}
