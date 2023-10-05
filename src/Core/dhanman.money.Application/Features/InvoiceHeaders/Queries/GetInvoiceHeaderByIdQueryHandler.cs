using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.InvoiceHeaders;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.InvoiceHeaders;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.InvoiceHeaders.Quries;

public class GetInvoiceHeaderByIdQueryHandler : IQueryHandler<GetInvoiceHeaderByIdQuery, Result<InvoiceHeaderResponse>>
{
    #region Properties
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructors
    public GetInvoiceHeaderByIdQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methodes
    public async Task<Result<InvoiceHeaderResponse>> Handle(GetInvoiceHeaderByIdQuery request, CancellationToken cancellationToken) =>
       await Result.Success(request)
           .Ensure(query => query.InvoiceHeadersId != Guid.Empty, Errors.General.EntityNotFound)
           .Bind(query =>
               _dbContext.Set<InvoiceHeader>().AsNoTracking()
                   .Where(e => e.Id == request.InvoiceHeadersId)
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
                   .FirstOrDefaultAsync(cancellationToken))
           .Ensure(response => response != null, Errors.General.EntityNotFound);
    #endregion

}
