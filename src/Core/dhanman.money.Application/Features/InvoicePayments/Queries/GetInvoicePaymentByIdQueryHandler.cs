using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.InvoicePayment;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.InvoicePayments;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.InvoicePayments.Queries;

public class GetInvoicePaymentByIdQueryHandler : IQueryHandler<GetInvoicePaymentByIdQuery, Result<InvoicePaymentResponse>>
{
    #region Properties
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructors
    public GetInvoicePaymentByIdQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    #endregion

    #region Methodes
    public async Task<Result<InvoicePaymentResponse>> Handle(GetInvoicePaymentByIdQuery request, CancellationToken cancellationToken) =>

        await Result.Success(request)
            .Ensure(query => query.InvoicePaymentId != Guid.Empty, Errors.General.EntityNotFound)
            .Bind(query =>
              _dbContext.Set<InvoicePayment>().AsNoTracking()
              .Where(e => e.Id == request.InvoicePaymentId)
              .Select(e => new InvoicePaymentResponse(
                  e.Id,
                  e.ClientId,
                  e.Amount,
                  e.InvoiceHeaderId,
                  e.TransactionId,
                  e.COAId,
                  e.CreatedOnUtc
            ))
              .FirstOrDefaultAsync(cancellationToken))
            .Ensure(response => response != null, Errors.General.EntityNotFound);
    #endregion

}
