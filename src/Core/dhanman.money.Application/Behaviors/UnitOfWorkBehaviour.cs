using dhanman.money.Application.Exceptions;
using dhanman.money.Domain.Abstractions;
using MediatR;
namespace dhanman.money.Application.Behaviors;

internal sealed class UnitOfWorkBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
{

    #region Properties

    private readonly IUnitOfWork _unitOfWork;

    #endregion

    #region Constructors
    public UnitOfWorkBehaviour(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    #endregion

    #region Methodes
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();
        if (request.IsQuery())
        {
            return response;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return response;
    }
    #endregion

}