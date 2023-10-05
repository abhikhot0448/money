using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.Invoice;

namespace dhanman.money.Application.Features.Invoice.Queries;

public class GetAllInvoicesQuery : ICacheableQuery<Result<InvoiceListResponse>>
{

    #region Properties
    public Guid Clientid;
    #endregion

    #region Constructors
    public GetAllInvoicesQuery(Guid clientId) => Clientid = clientId;
    #endregion

    #region Methodes
    public string GetCacheKey() => string.Format(CacheKeys.Invoices.InvoicesList, "user", Clientid);
    #endregion

}
