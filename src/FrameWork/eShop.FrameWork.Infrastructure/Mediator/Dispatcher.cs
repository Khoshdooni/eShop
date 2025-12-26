using eShop.SharedKernel.Application.Abstractions.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.FrameWork.Infrastructure.Mediator;

public class Dispatcher(IServiceProvider provider) : IDispatcher
{
    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken token)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var requestType = request.GetType();
        var responseType = typeof(TResponse);

        var method = typeof(Dispatcher)
            .GetMethod(
                nameof(ExecuteHandler),
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic
            )!
            .MakeGenericMethod(requestType, responseType);

        return (Task<TResponse>)method.Invoke(this, new object[] { request, token })!;
    }

    private Task<TResponse> ExecuteHandler<TRequest, TResponse>(
       TRequest request,
       CancellationToken token
    )
       where TRequest : IRequest<TResponse>
    {
        var handler = provider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();

        return handler.Handle(request, token);
    }
}
