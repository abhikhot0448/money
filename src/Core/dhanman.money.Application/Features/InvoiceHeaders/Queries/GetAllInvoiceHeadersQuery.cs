using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.InvoiceHeaders;

namespace dhanman.money.Application.Features.InvoiceHeaders.Queries;
public class GetAllInvoiceHeadersQuery : ICacheableQuery<Result<InvoiceHeaderListResponse>>
 {
    #region Properties
    public Guid Clientid;
    #endregion

    #region Constructors
    public GetAllInvoiceHeadersQuery(Guid clientId) => Clientid = clientId;
    #endregion

    #region Methodes
    public string GetCacheKey() => string.Format(CacheKeys.InvoiceHeaders.InvoiceHeaderList, "user", Clientid);
    #endregion

}

