using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Customers;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.Customers.Queries;

public class GetAllCustomersQueryHandler : IQueryHandler<GetAllCustomersQuery, Result<CustomerListResponse>>
{
    #region Properties
    private readonly IApplicationDbContext _dbContext;

    #endregion

    #region Constructors
    public GetAllCustomersQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methodes
    public async Task<Result<CustomerListResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        return await Result.Success(request)
        .Ensure(query => query != null, Errors.General.EntityNotFound)
              .Bind(async query =>
              {
                  var customers = await _dbContext.Set<Customer>()
                  .AsNoTracking()
                  .Where(e => e.ClientId == request.ClientId)
                  .Select(e => new CustomerResponse(
                          e.Id,
                          e.FirstName,
                          e.LastName,
                          e.Email,
                          e.PhoneNumber,
                          e.City,
                          e.CreatedOnUtc
                      ))
                  .ToListAsync(cancellationToken);

                  var listResponse = new CustomerListResponse(customers);

                  return listResponse;
              });
    }
    #endregion

}
