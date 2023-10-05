using B2aTech.CrossCuttingConcern.Core.Abstractions;
using Npgsql;
using System.Data;

namespace dhanman.money.Persistence.Data;

internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    #region Properties
    private readonly ConnectionString _connectionString;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="SqlConnectionFactory"/> class.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    public SqlConnectionFactory(ConnectionString connectionString) => _connectionString = connectionString;
    #endregion

    #region Methods
    /// <inheritdoc />
    public async Task<IDbConnection> CreateSqlConnectionAsync(CancellationToken cancellationToken)
    {
        var sqlConnection = new NpgsqlConnection(_connectionString);

        if (sqlConnection.State != ConnectionState.Open)
        {
            await sqlConnection.OpenAsync(cancellationToken);
        }

        return sqlConnection;
    }
    #endregion

}