using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.InvoiceStatuses;

namespace dhanman.money.Application.Features.InvoiceStatuses.Queries;

public class GetInvoiceStatusByIdQuery : ICacheableQuery<Result<InvoiceStatusResponse>>
{
    #region Properties
    /// <summary>
    /// Gets the income identifier.
    /// </summary>
    public Guid InvoiceStatusId { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="GetIncomeByIdQuery"/> class.
    /// </summary>
    /// <param name="incomeId">The income identifier.</param>
    /// <param name="userId">The user identifier.</param>
    public GetInvoiceStatusByIdQuery(Guid invioceStatusId) => InvoiceStatusId = invioceStatusId;
    #endregion

    #region Methodes
    public string GetCacheKey() => string.Format(CacheKeys.InvoiceStatus.InvoiceStatusById, "user", InvoiceStatusId);
    #endregion

}
