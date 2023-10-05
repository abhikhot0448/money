using DbUp.Engine;
using DbUp.Engine.Transactions;
using Dhanman.Money.Migrations.Core.Hashing;
using Dhanman.Money.Migrations.Core.Journal;
using System.Reflection;

namespace Dhanman.Money.Migrations.Core.ScriptProviders;

public class HashedEmbeddedScriptsProvider : IScriptProvider
{
    #region Properties
    private readonly Assembly _assembly;
    private readonly HashedSqlTableJournal _journal;
    #endregion

    #region Constructors
    public HashedEmbeddedScriptsProvider(Assembly assembly, HashedSqlTableJournal journal)
    {
        _assembly = assembly;
        _journal = journal;
    }
    #endregion

    #region Methodes
    /// <inheritdoc />
    public IEnumerable<SqlScript> GetScripts(IConnectionManager connectionManager)
    {
        Dictionary<string, string> executedScriptsDictionary = _journal.GetExecutedScriptsDictionary();

        IEnumerable<SqlScript> allSqlScripts = GetAllSqlScriptsEmbeddedInAssembly();

        return allSqlScripts
            .Where(sqlScript => !executedScriptsDictionary.TryGetValue(sqlScript.Name, out string sqlScriptHash) ||
                                SHA256.ComputeHash(sqlScript.Contents) != sqlScriptHash);
    }

    /// <summary>
    /// Gets all of the SQL scripts embedded in the assembly.
    /// </summary>
    /// <returns>The enumerable collection of all SQL scripts embedded in the assembly.</returns>
    private IEnumerable<SqlScript> GetAllSqlScriptsEmbeddedInAssembly()
    {
        IEnumerable<SqlScript> allSqlScripts = _assembly
            .GetManifestResourceNames()
            .Where(resourceName => resourceName.EndsWith(".sql", StringComparison.OrdinalIgnoreCase))
            .Select(resourceName => SqlScript.FromStream(resourceName, _assembly.GetManifestResourceStream(resourceName)))
            .OrderBy(sqlScript => sqlScript.Name);

        return allSqlScripts;
    }
    #endregion

}