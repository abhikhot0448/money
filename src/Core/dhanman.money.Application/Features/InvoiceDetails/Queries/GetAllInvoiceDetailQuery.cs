using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.InvoiceDetails;

namespace dhanman.money.Application.Features.InvoiceDetails.Queries;

public class GetAllInvoiceDetailQuery : ICacheableQuery<Result<InvoiceDetailListResponse>>
{
    #region Constructors
    public GetAllInvoiceDetailQuery()
    {

    }
    #endregion

    #region Methodes
    public string GetCacheKey() => string.Format(CacheKeys.InvoiceDetails.InvoiceDetailList, "user");
    #endregion

}
