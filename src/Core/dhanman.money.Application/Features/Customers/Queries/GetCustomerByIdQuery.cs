using B2aTech.CrossCuttingConcern.Core.Result;
using Dhanman.Money.Application.Abstractions.Messaging;
using Dhanman.Money.Application.Constants;
using Dhanman.Money.Application.Contracts.Customers;

namespace Dhanman.Money.Application.Features.Customers.Queries;

public sealed class GetCustomerByIdQuery : ICacheableQuery<Result<CustomerResponse>>
{
    #region Properties
    public Guid CustomerId { get; }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="GetIncomeByIdQuery"/> class.
    /// </summary>
    /// <param name="incomeId">The income identifier.</param>
    /// <param name="userId">The user identifier.</param>
    public GetCustomerByIdQuery(Guid customerId)
    {
        CustomerId = customerId;
    }
    #endregion

    #region Methodes
    public string GetCacheKey() => string.Format(CacheKeys.Customers.CustomerById, "user", CustomerId);
    #endregion

}