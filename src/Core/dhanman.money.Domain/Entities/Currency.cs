using B2aTech.CrossCuttingConcern.Core.Primitives;

namespace dhanman.money.Domain.Entities;

public sealed class Currency : Enumeration<Currency>
{
    #region Properties
    public static readonly Currency Usd = new Currency(1, "Dollar", "USD");
    public static readonly Currency Eur = new Currency(2, "Euro", "EUR");
    public static readonly Currency Rsd = new Currency(3, "Serbian dinar", "RSD");

    internal static readonly Currency None = new Currency(default, string.Empty, string.Empty);

    /// <summary>
    /// Gets the currency code.
    /// </summary>
    public string Code { get; }

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="Currency"/> class.
    /// </summary>
    /// <param name="value">The currency value.</param>
    /// <param name="name">The currency name.</param>
    /// <param name="code">The currency code.</param>
    private Currency(int value, string name, string code)
       : base(value, name)
    {
        Code = code;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Currency"/> class.
    /// </summary>
    /// <remarks>
    /// Required by EF Core.
    /// </remarks>
    private Currency()
    {
        Code = string.Empty;
    }

    #endregion

    #region Methodes
    /// <summary>
    /// Formats the specified amount with the specified currency.
    /// </summary>
    /// <param name="amount">The amount.</param>
    /// <returns>The formatted string with the amount and currency code.</returns>
    public string Format(decimal amount) => $"{amount:n2} {Code}";
    #endregion

}
