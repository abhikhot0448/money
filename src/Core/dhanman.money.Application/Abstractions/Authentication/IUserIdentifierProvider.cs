namespace Dhanman.Money.Application.Abstractions.Authentication;

public interface IUserIdentifierProvider
{
    Guid UserId { get; }
}