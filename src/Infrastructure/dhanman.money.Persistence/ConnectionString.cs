namespace Dhanman.Money.Persistence;

public sealed class ConnectionString
{
    #region Properties

    /// <summary>
    /// The connection strings key.
    /// </summary>
    public const string SettingsKey = "MoneyDb";


    /// <summary>
    /// Gets the connection string value.
    /// </summary>
    public string Value { get; }

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionString"/> class.
    /// </summary>
    /// <param name="value">The connection string value.</param>
    public ConnectionString(string value) => Value = value;
    #endregion

    #region Methods
    public static implicit operator string(ConnectionString connectionString) => connectionString.Value;
    #endregion

}
