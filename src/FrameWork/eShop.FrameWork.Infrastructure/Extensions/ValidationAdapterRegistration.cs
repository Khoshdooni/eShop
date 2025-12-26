using eShop.SharedKernel.Application.Abstractions.Validation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace eShop.FrameWork.Infrastructure.Extensions;

public static class ValidationAdapterRegistration
{
    public static IServiceCollection AddDomainRuleAdapters(
        this IServiceCollection services,
        Assembly assembly
    )
    {
        //? Automate Registration
        var validationInterface = typeof(IDomainValidationAdapter<>);
        assembly
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Select(t => new
            {
                Implementation = t,
                AdapterInterfaces = t.GetInterfaces()
                    .Where(i =>
                        i.GetInterfaces()
                            .Any(ii =>
                                ii.IsGenericType
                                && ii.GetGenericTypeDefinition() == validationInterface
                            )
                    ),
            })
            .Where(x => x.AdapterInterfaces.Any())
            .ToList()
            .ForEach(x =>
            {
                x.AdapterInterfaces.ToList().ForEach(i => services.AddScoped(i, x.Implementation));
            });

        return services;
    }
}
