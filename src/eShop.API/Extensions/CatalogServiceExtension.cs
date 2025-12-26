using eShop.Catalog.Infrastructure;
using eShop.Catalog.Presentation;

namespace eShop.API.Extensions;

public static class CatalogServiceExtension
{
    //public static IServiceCollection AddCatalogServices(
    //    this IServiceCollection services,
    //    IConfiguration configuration
    //)
    //{
    //    return services
    //        .AddValidatorsFromAssembly(Catalog.Presentation.AssemblyReference.Reference)
    //        .AddEndpoints(Catalog.Presentation.AssemblyReference.Reference)
    //        .AddMediator(Catalog.Application.AssemblyReference.Reference)
    //        .AddDbContextPool<CatalogContext>(builder =>
    //        {
    //            builder.UseSqlServer(configuration.GetConnectionString("Catalog"));
    //        });
    //}
    public static IServiceCollection AddCatalogServices(
    this IServiceCollection services,
    IConfiguration configuration
)
    {
        return services
                .AddCatalogInfrastructure(configuration).AddCatalogPresentation();
    }
}
