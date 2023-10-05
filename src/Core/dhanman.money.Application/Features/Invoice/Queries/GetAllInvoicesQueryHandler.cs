using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Contracts.Invoice;
using dhanman.money.Domain;
using dhanman.money.Domain.Entities.Customers;
using dhanman.money.Domain.Entities.InvoiceDetails;
using dhanman.money.Domain.Entities.InvoiceHeaders;
using dhanman.money.Domain.Entities.InvoiceStatuses;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Features.Invoice.Queries;

public class GetAllInvoicesQueryHandler : IQueryHandler<GetAllInvoicesQuery, Result<InvoiceListResponse>>
{
    #region Properties
    private readonly IApplicationDbContext _dbContext;

    #endregion

    #region Constructors
    public GetAllInvoicesQueryHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methodes
    public async Task<Result<InvoiceListResponse>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
    {
        return await Result.Success(request)
        .Ensure(query => query.Clientid != Guid.Empty, Errors.General.EntityNotFound)
        .Bind(async query =>
        {
            var invoiceHeaders = await _dbContext.Set<InvoiceHeader>()
                .AsNoTracking()
                .Where(ih => ih.ClientId == query.Clientid)
                .Select(ih => new InvoiceResponse(
                    ih.Id,
                    ih.InvoicePaymentId,
                    ih.InvoiceNumber,
                    ih.InvoiceVoucher,
                    ih.COAId,
                    _dbContext.Set<Customer>()
                     .Where(customer => customer.Id == ih.CustomerId)
                     .Select(customer => customer.FirstName + " " + customer.LastName)
                     .FirstOrDefault(),
                    ih.DueDate,
                    ih.InvoiceDate,
                    ih.PaymentTerm,
                    ih.TotalAmount,
                    ih.Currency,
                    _dbContext.Set<InvoiceStatus>()
                    .Where(status => status.Id == ih.InvoiceStatusId)
                    .Select(status => status.Name)
                    .FirstOrDefault(),
                    ih.Tax,
                    ih.Discount,
                    ih.Note,
                    ih.CreatedOnUtc,
                    _dbContext.Set<InvoiceDetail>()
                       .Where(detail => detail.InvoiceHeaderId == ih.Id)
                       .Select(detail => new InvoiceLine(
                           detail.Name,
                           detail.Description,
                           detail.Price,
                           detail.Quantity,
                           detail.Amount
                           ))
                          .ToList()
                    ))
                .ToListAsync(cancellationToken);

            var listResponse = new InvoiceListResponse(invoiceHeaders);

            return listResponse;
        });

    }
    #endregion

}
