namespace dhanman.money.Domain.Abstractions;

public interface IUnitOfWork
{
    #region Methodes

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    #endregion
}
