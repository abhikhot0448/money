using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.InvoiceHeaders;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.InvoiceHeaders;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.InvoiceHeaders.Queries;

public class GetAllInvoiceHeadersQueryHandler : IQueryHandler<GetAllInvoiceHeadersQuery, Result<InvoiceHeaderListResponse>>
{

    #region Properties
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructors
    public GetAllInvoiceHeadersQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methodes
    public async Task<Result<InvoiceHeaderListResponse>> Handle(GetAllInvoiceHeadersQuery request, CancellationToken cancellationToken)
    {
        return await Result.Success(request)
            .Ensure(query => query.Clientid != Guid.Empty, Errors.General.EntityNotFound)
            .Bind(async query =>
            {
                var invoiceHeaders = await _dbContext.Set<InvoiceHeader>()
                    .AsNoTracking()
                    .Where(e => e.ClientId == query.Clientid)
                    .Select(e => new InvoiceHeaderResponse(
                        e.Id,
                        e.InvoicePaymentId,
                        e.InvoiceNumber,
                        e.InvoiceVoucher,
                        e.COAId,
                        e.CustomerId,
                        e.DueDate,
                        e.InvoiceDate,
                        e.PaymentTerm,
                        e.TotalAmount,
                        e.Tax,
                        e.Discount,
                        e.Note,
                        e.Currency
                        ))
                    .ToListAsync(cancellationToken);

                var listResponse = new InvoiceHeaderListResponse(invoiceHeaders);

                return listResponse;
            });
    }
    #endregion

}
