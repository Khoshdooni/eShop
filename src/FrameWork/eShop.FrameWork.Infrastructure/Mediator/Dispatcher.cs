using eShop.SharedKernel.Application.Abstractions.Mediator;

namespace eShop.FrameWork.Infrastructure.Mediator;

public class Dispatcher : IDispatcher
{
    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
