using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.InvoicePayment;

namespace dhanman.money.Application.Features.InvoicePayments.Queries;

public class GetInvoicePaymentByIdQuery : ICacheableQuery<Result<InvoicePaymentResponse>>
{
    #region Properties
    public Guid InvoicePaymentId { get; }
    #endregion

    #region Constructors
    public GetInvoicePaymentByIdQuery(Guid inviocePaymentId) => InvoicePaymentId = inviocePaymentId;
    #endregion

    #region Methodes
    public string GetCacheKey() => string.Format(CacheKeys.InvoicePayments.InvoicePaymentById, "user", InvoicePaymentId);
    #endregion

}
