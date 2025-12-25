using eShop.FrameWork.Infrastructure.Mediator;
using eShop.FrameWork.Presentation.Extensions;
using FluentValidation;

namespace eShop.API.Extensions;

public static class CatalogServiceExtension
{
    public static IServiceCollection AddCatalogServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        return services
            .AddValidatorsFromAssembly(Catalog.Presentation.AssemblyReference.Reference)
            .AddEndpoints(Catalog.Presentation.AssemblyReference.Reference)
            .AddMediator(Catalog.Application.AssemblyReference.Reference)
            .AddDbContextPool<CatalogContext>(builder =>
            {
                builder.UseSqlServer(configuration.GetConnectionString("Catalog"));
            });
    }
}
