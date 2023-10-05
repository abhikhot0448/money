using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.Customers;

namespace dhanman.money.Application.Features.Customers.Queries;

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