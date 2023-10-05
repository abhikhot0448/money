using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.InvoiceDetails;

namespace dhanman.money.Application.Features.InvoiceDetails.Queries;

public sealed class GetInvoiceDetailByIdQuery : ICacheableQuery<Result<InvoiceDetailResponse>>
{
    #region Properties
    public Guid InvoiceDetailId { get; }
    #endregion

    #region Constructors
    public GetInvoiceDetailByIdQuery(Guid invoiceDetailId)
    {
        InvoiceDetailId = invoiceDetailId;
    }
    #endregion

    #region Methodes
    public string GetCacheKey() => string.Format(CacheKeys.InvoiceDetails.InvoiceDetailById, "user", InvoiceDetailId);
    #endregion

}

