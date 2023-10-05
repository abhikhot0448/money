namespace Dhanman.Domain.Core.Abstractions;

public interface IDbExecutor
{
    Task<T[]> QueryAsync<T>(string sql, object parameters);
}
