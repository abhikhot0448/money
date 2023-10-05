using B2aTech.CrossCuttingConcern.Core.Primitives;

namespace Dhanman.Domain.Core.Result;

public class Result
{
    #region Properties
   
    public bool IsSuccess { get; }
    
    public bool IsFailure => !IsSuccess;
   
    public Error Error { get; }


    #endregion

    #region Constructors
    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }
    #endregion

    #region Methodes

    /// <summary>
    /// Gets a value indicating whether the result is a success result.
    /// </summary>
    /// <summary>
    /// Gets a value indicating whether the result is a failure result.
    /// </summary>
    public static Result Success() => new Result(true, Error.None);

    public static Result<TValue> Success<TValue>(TValue value) => new Result<TValue>(value, true, Error.None);

    public static Result<TValue> Create<TValue>(TValue? value, Error error)
        where TValue : class
        => value ?? Failure<TValue>(error);

    public static Result Failure(Error error) => new Result(false, error);

    public static Result<TValue> Failure<TValue>(Error error) => new Result<TValue>(default!, false, error);

    public static Result FirstFailureOrSuccess(params Result[] results)
    {
        foreach (Result result in results)
        {
            if (result.IsFailure)
            {
                return result;
            }
        }

        return Success();
    }

    #endregion

}

public class Result<TValue> : Result
{
    #region Properties
    private readonly TValue _value;

    #endregion

    #region Constructors
    protected internal Result(TValue value, bool isSuccess, Error error)
    : base(isSuccess, error)
    => _value = value;
    #endregion

    #region Methodes
    public TValue Value()
    {
        if (IsFailure)
        {
            throw new InvalidOperationException();
        }

        return _value;
    }

    public static implicit operator Result<TValue>(TValue value) => Success(value);

    #endregion

}