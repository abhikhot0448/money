﻿using B2aTech.CrossCuttingConcern.Core.Primitives;
using dhanman.money.Domain.Utility;

namespace dhanman.money.Domain.Entities;

public sealed class Money : ValueObject
{
    #region Properties
    public static readonly Money None = new Money();
    /// <summary>
    /// Gets the money amount.
    /// </summary>
    public decimal Amount { get; }
    /// <summary>
    /// Gets the money currency.
    /// </summary>
    public Currency Currency { get; }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="Money"/> class.
    /// </summary>
    /// <param name="amount">The money amount.</param>
    /// <param name="currency">The currency instance.</param>
    public Money(decimal amount, Currency currency)
    {
        Ensure.NotEmpty(currency, "The currency is required.", nameof(currency));

        Amount = amount;
        Currency = currency;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Money"/> class.
    /// </summary>
    /// <remarks>
    /// Required by EF Core.
    /// </remarks>
    private Money()
    {
        Currency = Currency.None;
    }
    #endregion

    #region Methodes
    public static Money operator +(Money left, Money right)
    {
        AssertCurrenciesAreEqual(left, right);

        return new Money(left.Amount + right.Amount, left.Currency);
    }

    public static Money operator -(Money left, Money right)
    {
        AssertCurrenciesAreEqual(left, right);

        return new Money(left.Amount - right.Amount, left.Currency);
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Amount;
        yield return Currency;
    }

    private static void AssertCurrenciesAreEqual(Money left, Money right)
    {
        if (left.Currency != right.Currency)
        {
            throw new InvalidOperationException(
                $"The currencies {left.Currency.Name} and {right.Currency.Name} are not the same currency.");
        }
    }
    #endregion

}