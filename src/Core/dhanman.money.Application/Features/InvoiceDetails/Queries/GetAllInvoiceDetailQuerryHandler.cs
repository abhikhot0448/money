using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.InvoiceDetails;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.InvoiceDetails;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.InvoiceDetails.Queries;

public class GetAllInvoiceDetailQuerryHandler : IQueryHandler<GetAllInvoiceDetailQuery, Result<InvoiceDetailListResponse>>
{
    #region Properties
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructors
    public GetAllInvoiceDetailQuerryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methodes
    public async Task<Result<InvoiceDetailListResponse>> Handle(GetAllInvoiceDetailQuery request, CancellationToken cancellationToken)
    {
        return await Result.Success(request)
              .Ensure(query => query != null, Errors.General.EntityNotFound)
              .Bind(async query =>
              {
                  var invoiceDetails = await _dbContext.Set<InvoiceDetail>()
                  .AsNoTracking()
                  .Where(e => e.InvoiceHeaderId != null)
                  .Select(e => new InvoiceDetailResponse(
                          e.Id,
                          e.InvoiceHeaderId,
                          e.Name,
                          e.Description,
                          e.Price,
                          e.Quantity,
                          e.Amount,
                          e.CreatedOnUtc
                      ))
                  .ToListAsync(cancellationToken);

                  var listResponse = new InvoiceDetailListResponse(invoiceDetails);

                  return listResponse;
              });
    }
    #endregion


}
