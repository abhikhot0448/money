using dhanman.money.Application.Contracts.Authentication;
using dhanman.money.Domain.Entities.Users;

namespace dhanman.money.Application.Abstractions.Authentication;

public interface IJwtProvider
{
    Task<TokenResponse> CreateAsync(User user);
}
