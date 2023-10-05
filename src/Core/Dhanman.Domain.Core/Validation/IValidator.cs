namespace Dhanman.Domain.Core.Validation;

public interface IValidator<T>
        where T : class
{
    #region Methodes
    IValidator<T> SetNext(IValidator<T> next);

    Result.Result Validate(T? item);
    #endregion

}