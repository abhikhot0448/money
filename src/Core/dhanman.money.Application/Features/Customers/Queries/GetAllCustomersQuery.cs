using B2aTech.CrossCuttingConcern.Core.Result;
using Dhanman.Money.Application.Abstractions.Messaging;
using Dhanman.Money.Application.Constants;
using Dhanman.Money.Application.Contracts.Customers;

namespace Dhanman.Money.Application.Features.Customers.Queries;

public class GetAllCustomersQuery : ICacheableQuery<Result<CustomerListResponse>>
{
    #region Properties
    public Guid ClientId { get; }
    #endregion

    #region Constructors
    public GetAllCustomersQuery(Guid clientId)
    {
        ClientId = clientId;
    }

    #endregion

    #region Methodes
    public string GetCacheKey() => string.Format(CacheKeys.Customers.CustomerList, "user", ClientId);
    #endregion

}