using eShop.FrameWork.Presentation.Extensions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.Catalog.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddCatalogPresentation(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        return services.AddValidatorsFromAssembly(assembly).AddEndpoints(assembly);
    }
}
