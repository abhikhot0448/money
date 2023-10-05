using B2aTech.CrossCuttingConcern.Core.Result;
using dhanman.money.Application.Contracts.Authentication;
using dhanman.money.Domain.Entities.Customers;
using dhanman.money.Domain.Entities.Users;

namespace dhanman.money.Application.Abstractions.Authentication;

public interface IAuthenticationService
{
    #region Methodes

    Task<Result<TokenResponse>> RegisterAsync(string firstName, string lastName, Email email, Password password);

    Task<Result<TokenResponse>> LoginAsync(string email, string password);

    #endregion
}
