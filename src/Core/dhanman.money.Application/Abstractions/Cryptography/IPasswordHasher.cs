using Dhanman.Money.Domain.Entities.Users;

namespace Dhanman.Money.Application.Abstractions.Cryptography;

public interface IPasswordHasher
{
    string HashPassword(Password password);
}
