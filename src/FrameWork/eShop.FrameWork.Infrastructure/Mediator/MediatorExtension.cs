using eShop.SharedKernel.Application.Abstractions.Mediator;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace eShop.FrameWork.Infrastructure.Mediator;

public static class MediatorExtension
{
    public static IServiceCollection AddMediator(this IServiceCollection services, Assembly assembly)
    {
        services.AddScoped<IDispatcher, Dispatcher>();
        return services;
    }
}
