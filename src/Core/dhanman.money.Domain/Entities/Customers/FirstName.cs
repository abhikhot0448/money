using B2aTech.CrossCuttingConcern.Core.Primitives;
using B2aTech.CrossCuttingConcern.Core.Result;

namespace dhanman.money.Domain.Entities.Customers;

public sealed class FirstName : ValueObject
{
    #region Properties
    public const int MaxLength = 100;

    public string Value { get; }

    internal static FirstName Empty => new FirstName(string.Empty);
    #endregion

    #region Constructors
    /// <summary>
    /// Gets the empty first name instance.
    /// </summary>
    private FirstName(string value) => Value = value;
    #endregion

    #region Methodes
    public static implicit operator string(FirstName? firstName) => firstName?.Value ?? string.Empty;

    public static Result<FirstName> Create(string? firstName) =>
       Result.Create(firstName, Errors.FirstName.NullOrEmpty)
           .Ensure(f => !string.IsNullOrWhiteSpace(f), Errors.FirstName.NullOrEmpty)
           .Ensure(f => f.Length <= MaxLength, Errors.FirstName.LongerThanAllowed)
           .Map(f => new FirstName(f));

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
