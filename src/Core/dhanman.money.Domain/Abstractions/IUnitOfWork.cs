namespace Dhanman.Money.Domain.Abstractions;

public interface IUnitOfWork
{
    #region Methodes

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    #endregion
}
