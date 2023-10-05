using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhanman.Domain.Core.Validation;

public abstract class Validator<T> : IValidator<T>
        where T : class
{
    #region Properties
    private IValidator<T>? _next;
    #endregion

    #region Methodes
    public IValidator<T> SetNext(IValidator<T> next)
    {
        if (_next is null)
        {
            _next = next;
        }
        else
        {
            _next.SetNext(next);
        }

        return this;
    }

    public virtual Result.Result Validate(T? item) => _next?.Validate(item) ?? Result.Result.Success();
    #endregion

}