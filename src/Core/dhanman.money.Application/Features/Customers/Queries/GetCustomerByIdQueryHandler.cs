using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Customers;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.Customers.Queries;

internal sealed class GetCustomerByIdQueryHandler : IQueryHandler<GetCustomerByIdQuery, Result<CustomerResponse>>
{
    #region Properties
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructors
    public GetCustomerByIdQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methodes
    public async Task<Result<CustomerResponse>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken) =>
        await Result.Success(request)
            .Ensure(query => query.CustomerId != Guid.Empty, Errors.General.EntityNotFound)
            .Bind(query =>
                _dbContext.Set<Customer>().AsNoTracking()
                    .Where(e => e.Id == request.CustomerId)
                    .Select(e => new CustomerResponse(
                        e.Id,
                        e.FirstName,
                        e.LastName,
                        e.Email,
                        e.PhoneNumber,
                        e.City,
                        e.CreatedOnUtc))
                    .FirstOrDefaultAsync(cancellationToken))
            .Ensure(response => response != null, Errors.General.EntityNotFound);
    #endregion
    
}
