using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.InvoiceStatuses;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.InvoiceStatuses;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.InvoiceStatuses.Queries;

public class GetInvoiceStatusByIdQueryHandler : IQueryHandler<GetInvoiceStatusByIdQuery, Result<InvoiceStatusResponse>>
{

    #region Properties
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructors
    public GetInvoiceStatusByIdQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methodes
    public async Task<Result<InvoiceStatusResponse>> Handle(GetInvoiceStatusByIdQuery request, CancellationToken cancellationToken) =>
       await Result.Success(request)
           .Ensure(query => query.InvoiceStatusId != Guid.Empty, Errors.General.EntityNotFound)
           .Bind(query =>
               _dbContext.Set<InvoiceStatus>().AsNoTracking()
                   .Where(e => e.Id == request.InvoiceStatusId)
                   .Select(e => new InvoiceStatusResponse(
                       e.Id,
                       e.Name,
                       e.ClientId,
                       e.CreatedOnUtc
                      ))
                   .FirstOrDefaultAsync(cancellationToken))
           .Ensure(response => response != null, Errors.General.EntityNotFound);
    #endregion

}
