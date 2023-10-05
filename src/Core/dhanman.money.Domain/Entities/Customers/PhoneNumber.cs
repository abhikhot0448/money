using B2aTech.CrossCuttingConcern.Core.Primitives;
using B2aTech.CrossCuttingConcern.Core.Result;
using System.Text.RegularExpressions;

namespace Dhanman.Money.Domain.Entities.Customers;

public sealed class PhoneNumber : ValueObject
{
    #region Properties
    /// <summary>
    /// The maximum length for a phone number.
    /// </summary>
    public const int MaxLength = 15; // Adjust this as needed based on your requirements.
    private const string PhoneNumberRegexPattern = @"^[0-9]+$"; // Modify the regex pattern as needed.

    private static readonly Lazy<Regex> PhoneNumberFormatRegex =
       new Lazy<Regex>(() => new Regex(PhoneNumberRegexPattern, RegexOptions.Compiled));

    /// <summary>
    /// Gets the phone number value.
    /// </summary>
    public string Value { get; }
    
    /// <summary>
    /// Gets the empty phone number instance.
    /// </summary>

    internal static PhoneNumber Empty => new PhoneNumber(string.Empty);

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="PhoneNumber"/> class.
    /// </summary>
    /// <param name="value">The phone number value.</param>
    private PhoneNumber(string value) => Value = value;
    #endregion

    #region Methodes
    public static implicit operator string(PhoneNumber? phoneNumber) => phoneNumber?.Value ?? string.Empty;

    public static explicit operator PhoneNumber(string phoneNumber) => Create(phoneNumber).Value();

    /// <summary>
    /// Creates a new <see cref="PhoneNumber"/> instance based on the specified value.
    /// </summary>
    /// <param name="phoneNumber">The phone number value.</param>
    /// <returns>The result of the phone number creation process containing the phone number or an error.</returns>
    public static Result<PhoneNumber> Create(string? phoneNumber) =>
    Result.Create(phoneNumber, Errors.PhoneNumber.NullOrEmpty)
        .Ensure(p => !string.IsNullOrWhiteSpace(p), Errors.PhoneNumber.NullOrEmpty)
        .Ensure(p => p.Length <= MaxLength, Errors.PhoneNumber.LongerThanAllowed)
        .Ensure(p => PhoneNumberFormatRegex.Value.IsMatch(p), Errors.PhoneNumber.InvalidFormat)
        .Map(p => new PhoneNumber(p));

    /// <inheritdoc />
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
    #endregion
   
}

