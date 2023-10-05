using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.InvoiceDetails;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.InvoiceDetails;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.InvoiceDetails.Queries;

public sealed class GetInvoiceDetailByIdQueryHandler : IQueryHandler<GetInvoiceDetailByIdQuery, Result<InvoiceDetailResponse>>
{
    #region Properties
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructors
    public GetInvoiceDetailByIdQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methodes
    public async Task<Result<InvoiceDetailResponse>> Handle(GetInvoiceDetailByIdQuery request, CancellationToken cancellationToken) =>
       await Result.Success(request)
           .Ensure(query => query.InvoiceDetailId != Guid.Empty, Errors.General.EntityNotFound)
           .Bind(query =>
               _dbContext.Set<InvoiceDetail>().AsNoTracking()
                   .Where(e => e.Id == request.InvoiceDetailId)
                   .Select(e => new InvoiceDetailResponse(
                       e.Id,
                       e.InvoiceHeaderId,
                       e.Name,
                       e.Description,
                       e.Price,
                       e.Quantity,
                       e.Amount,
                       e.CreatedOnUtc))
                   .FirstOrDefaultAsync(cancellationToken))
           .Ensure(response => response != null, Errors.General.EntityNotFound);
    #endregion

}
