using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.InvoiceHeaders;

namespace dhanman.money.Application.Features.InvoiceHeaders.Quries;

public class GetInvoiceHeaderByIdQuery : ICacheableQuery<Result<InvoiceHeaderResponse>>
{
    #region Properties
    public Guid InvoiceHeadersId { get; }
    #endregion

    #region Constructors
    public GetInvoiceHeaderByIdQuery(Guid invioceHeaderId) => InvoiceHeadersId = invioceHeaderId;
    #endregion

    #region Methodes
    public string GetCacheKey() => string.Format(CacheKeys.InvoiceHeaders.InvoiceHeaderById, "user", InvoiceHeadersId);
    #endregion

}
