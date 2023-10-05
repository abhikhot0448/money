using Dhanman.Money.Application.Contracts.Authentication;
using Dhanman.Money.Domain.Entities.Users;

namespace Dhanman.Money.Application.Abstractions.Authentication;

public interface IJwtProvider
{
    Task<TokenResponse> CreateAsync(User user);
}
