namespace dhanman.money.Application.Abstractions.Authentication;

public interface IUserIdentifierProvider
{
    Guid UserId { get; }
}