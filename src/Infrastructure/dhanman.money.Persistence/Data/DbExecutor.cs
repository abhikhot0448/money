﻿using B2aTech.CrossCuttingConcern.Core.Abstractions;
using Dapper;
using System.Data;

namespace dhanman.money.Persistence.Data;

internal sealed class DbExecutor : IDbExecutor
{
    #region Properties
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="DbExecutor"/> class.
    /// </summary>
    /// <param name="sqlConnectionFactory">The sql connection factory.</param>
    public DbExecutor(ISqlConnectionFactory sqlConnectionFactory) => _sqlConnectionFactory = sqlConnectionFactory;
    #endregion

    #region Methods
    /// <inheritdoc />
    public async Task<T[]> QueryAsync<T>(string sql, object parameters)
    {
        using IDbConnection connection = await _sqlConnectionFactory.CreateSqlConnectionAsync();

        IEnumerable<T> result = await connection.QueryAsync<T>(sql, parameters);

        return result.ToArray();
    }
    #endregion





}
