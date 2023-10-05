using B2aTech.CrossCuttingConcern.Core.Primitives;
using B2aTech.CrossCuttingConcern.Core.Result;

namespace Dhanman.Money.Domain.Entities.Customers;

public sealed class LastName : ValueObject
{
    #region Properties
    /// <summary>
    /// The last name maximum length.
    /// </summary>
    public const int MaxLength = 100;

    /// <summary>
    /// Gets the last name value.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Gets the empty last name instance.
    /// </summary>
    internal static LastName Empty => new LastName(string.Empty);

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="LastName"/> class.
    /// </summary>
    /// <param name="value">The last name value.</param>
    private LastName(string value) => Value = value;
    #endregion

    #region Methodes
    public static implicit operator string(LastName? lastName) => lastName?.Value ?? string.Empty;


    /// <summary>
    /// Creates a new <see cref="FirstName"/> instance based on the specified value.
    /// </summary>
    /// <param name="lastName">The last name value.</param>
    /// <returns>The result of the last name creation process containing the last name or an error.</returns>
    public static Result<LastName> Create(string? lastName) =>
       Result.Create(lastName, Errors.LastName.NullOrEmpty)
           .Ensure(l => !string.IsNullOrWhiteSpace(l), Errors.LastName.NullOrEmpty)
           .Ensure(l => l.Length <= MaxLength, Errors.LastName.LongerThanAllowed)
           .Map(l => new LastName(l));

    /// <summary>
    /// Gets the atomic values of the value object.
    /// </summary>
    /// <returns>The collection of objects representing the value object values.</returns>
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    #endregion

}
