namespace Dhanman.Money.Domain.Entities.Users.Services;

public interface IPasswordHashChecker
{
    bool HashesMatch(string passwordHash, string providedPassword);
}
