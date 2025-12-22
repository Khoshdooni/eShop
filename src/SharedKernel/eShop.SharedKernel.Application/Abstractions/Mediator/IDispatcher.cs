namespace eShop.SharedKernel.Application.Abstractions.Mediator;

public interface IDispatcher
{
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken token);
}



