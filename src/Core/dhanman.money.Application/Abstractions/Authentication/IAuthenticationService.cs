using B2aTech.CrossCuttingConcern.Core.Result;
using Dhanman.Money.Application.Contracts.Authentication;
using Dhanman.Money.Domain.Entities.Customers;
using Dhanman.Money.Domain.Entities.Users;

namespace Dhanman.Money.Application.Abstractions.Authentication;

public interface IAuthenticationService
{
    #region Methodes

    Task<Result<TokenResponse>> RegisterAsync(string firstName, string lastName, Email email, Password password);

    Task<Result<TokenResponse>> LoginAsync(string email, string password);

    #endregion
}
