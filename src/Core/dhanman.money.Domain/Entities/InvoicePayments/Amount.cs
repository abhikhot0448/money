using B2aTech.CrossCuttingConcern.Core.Primitives;
using B2aTech.CrossCuttingConcern.Core.Result;

namespace dhanman.money.Domain.Entities.InvoicePayments;

public sealed class Amount : ValueObject
{
    #region Properties
    public decimal Value { get; }

    internal static Amount Empty => new Amount(0); // You can define an empty value for Amount
    #endregion

    #region Constructors
    private Amount(decimal value) => Value = value;
    #endregion

    #region Methods
    public static implicit operator decimal(Amount? amount) => amount?.Value ?? 0;

    public static Result<Amount> Create(decimal? amountValue)
    {
        if (amountValue == null || amountValue <= 0)
        {
            return Result.Failure<Amount>(Errors.Amount.InvalidValue);
        }

        return Result.Success(new Amount(amountValue.Value));
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
    #endregion
}
