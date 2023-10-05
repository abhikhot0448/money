using System.Data;

namespace Dhanman.Domain.Core.Abstractions;

public interface ISqlConnectionFactory
{
    Task<IDbConnection> CreateSqlConnectionAsync(CancellationToken cancellationToken = default);
}