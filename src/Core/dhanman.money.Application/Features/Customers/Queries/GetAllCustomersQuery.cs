using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Constants;
using dhanman.money.Application.Contracts.Customers;

namespace dhanman.money.Application.Features.Customers.Queries;

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