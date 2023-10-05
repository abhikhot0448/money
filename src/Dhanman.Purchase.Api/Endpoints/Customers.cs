﻿using Carter;
using MediatR;

namespace Dhanman.Money.Api.Endpoints;

public class Customers : ICarterModule
{
    #region Properties
    protected IMediator Mediator { get; }
    //private readonly IUserIdentifierProvider _userIdentifierProvider;
    #endregion

    #region Constructors
    protected Customers(IMediator mediator)
    {
        Mediator = mediator;
    }
    #endregion

    #region Methods
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        //app.MapPost("customers", async (CreateCustomerRequest request, ISender sender) =>
        //{
        //    await Result.Create(request, Errors.General.BadRequest)
        //       .Map(value => new CreateCustomerCommand(
        //           Guid.NewGuid(),
        //           value.FirstName,
        //           value.LastName,
        //           value.Email))
        //       .Bind(command => Mediator.Send(command))
        //       .Match(
        //           entityCreated => CreatedAtAction(nameof(GetIncomeById), new { id = entityCreated.Id }, entityCreated),
        //           BadRequest);

        //    var result = await sender.Send(command);

        //    return Results.Ok();
        //});

        //app.MapGet("customers/{id}", async (Guid clientId, ISender sender) =>
        //{
        //    var query = new GetCustomerQuery(clientId);

        //    return Results.Ok(await sender.Send(query));
        //});
    }
    #endregion

}