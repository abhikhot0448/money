﻿using B2aTech.CrossCuttingConcern.Core.Primitives;
using B2aTech.CrossCuttingConcern.Core.Result;

namespace dhanman.money.Domain.Entities.Users;

public sealed class Password : ValueObject
{
    #region Properties
    private const int MinPasswordLength = 6;
    private static readonly Func<char, bool> IsLower = c => c >= 'a' && c <= 'z';
    private static readonly Func<char, bool> IsUpper = c => c >= 'A' && c <= 'Z';
    private static readonly Func<char, bool> IsDigit = c => c >= '0' && c <= '9';
    private static readonly Func<char, bool> IsNonAlphaNumeric = c => !(IsLower(c) || IsUpper(c) || IsDigit(c));
    public string Value { get; }
    #endregion

    #region Constructors
    private Password(string value) => Value = value;
    #endregion

    #region Methodes
    public static implicit operator string(Password? password) => password?.Value ?? string.Empty;

    public static Result<Password> Create(string? password) =>
        Result.Create(password, Errors.Password.NullOrEmpty)
            .Ensure(p => !string.IsNullOrWhiteSpace(p), Errors.Password.NullOrEmpty)
            .Ensure(p => p.Length >= MinPasswordLength, Errors.Password.TooShort)
            .Ensure(p => p.Any(IsLower), Errors.Password.MissingLowercaseLetter)
            .Ensure(p => p.Any(IsUpper), Errors.Password.MissingUppercaseLetter)
            .Ensure(p => p.Any(IsDigit), Errors.Password.MissingDigit)
            .Ensure(p => p.Any(IsNonAlphaNumeric), Errors.Password.MissingNonAlphaNumeric)
            .Map(p => new Password(p));

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    #endregion

}
