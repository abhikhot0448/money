using dhanman.money.Domain.Entities.Users;

namespace dhanman.money.Application.Abstractions.Cryptography;

public interface IPasswordHasher
{
    string HashPassword(Password password);
}
