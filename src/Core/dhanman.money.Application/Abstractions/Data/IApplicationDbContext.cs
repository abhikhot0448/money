using B2aTech.CrossCuttingConcern.Core.Primitives;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Application.Abstractions.Data;


public interface IApplicationDbContext
{
    #region Methodes

    DbSet<TEntity> Set<TEntity>()
           where TEntity : Entity;

    Task<TEntity?> GetBydIdAsync<TEntity>(Guid id)
            where TEntity : Entity;

    void Insert<TEntity>(TEntity entity)
           where TEntity : Entity;

    void Update<TEntity>(TEntity entity)
           where TEntity : Entity;

    void Remove<TEntity>(TEntity entity)
           where TEntity : Entity;

    #endregion
}

