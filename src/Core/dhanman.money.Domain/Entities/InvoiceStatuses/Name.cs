using B2aTech.CrossCuttingConcern.Core.Primitives;
using B2aTech.CrossCuttingConcern.Core.Result;

namespace dhanman.money.Domain.Entities.InvoiceStatuses;

public class Name : ValueObject
{
    #region Properties
    public const int MaxLength = 100;
    public string Value { get; }
    /// <summary>
    /// Gets the empty first name instance.
    /// </summary>

    internal static Name Empty => new Name(string.Empty);

    #endregion

    #region Constructors
    private Name(string value) => Value = value;
    #endregion

    #region Methodes
    public static implicit operator string(Name? name) => name?.Value ?? string.Empty;

    public static Result<Name> Create(string? name) =>
        Result.Create(name, Errors.FirstName.NullOrEmpty)
            .Ensure(f => !string.IsNullOrWhiteSpace(f), Errors.FirstName.NullOrEmpty)
            .Ensure(f => f.Length <= MaxLength, Errors.Name.LongerThanAllowed)
            .Map(f => new Name(f));

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
