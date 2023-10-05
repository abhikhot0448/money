using dhanman.money.Application.Abstractions.Messaging;
using dhanman.money.Application.Exceptions;
using FluentValidation;
using MediatR;
using ValidationException = dhanman.money.Application.Exceptions.ValidationException;

namespace dhanman.money.Application.Behaviors;

public sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
where TRequest : class, ICommand<TResponse>
{
    #region Properties
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    #endregion

    #region Constructors
    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;
    #endregion

    #region Methodes
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        //Validate and then Await
        var context = new ValidationContext<TRequest>(request);

        var validationFailures = await Task.WhenAll(
            _validators.Select(validator => validator.ValidateAsync(context)));

        var errors = validationFailures
            .Where(validationResult => !validationResult.IsValid)
            .SelectMany(validationResult => validationResult.Errors)
            .Select(validationFailure => new ValidationError(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage))
            .ToList();

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        var response = await next();

        return response;
    }
    #endregion

}
