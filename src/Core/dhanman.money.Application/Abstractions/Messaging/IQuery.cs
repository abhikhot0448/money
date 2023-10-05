using MediatR;

namespace Dhanman.Money.Application.Abstractions.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
