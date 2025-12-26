using eShop.SharedKernel.Application.Abstractions.Mediator;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace eShop.FrameWork.Infrastructure.Mediator;

public static class MediatorExtension
{
    public static IServiceCollection AddMediator(this IServiceCollection services, Assembly assembly)
    {
        services.AddScoped<IDispatcher, Dispatcher>();
        var handlerInterfaceType = typeof(IRequestHandler<,>);
        var types = assembly
            .GetTypes()
            .Where(t =>
                t.IsClass
                && !t.IsAbstract
                && !t.IsGenericType
                && t.GetInterfaces()
                    .Any(i =>
                        i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterfaceType
                    )
            );
        //? Command -> One Handler
        //? Event -> Many Handler

        foreach (var handlerType in types)
        {
            var interfaces = handlerType
                .GetInterfaces()
                .Where(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterfaceType
                );

            foreach (var handlerInterface in interfaces)
            {
                services.AddScoped(handlerInterface, handlerType);
            }
        }

        return services;
    }
}
