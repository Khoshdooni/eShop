using eShop.Catalog.Infrastructure.Data;
using eShop.FrameWork.Infrastructure.Extensions;
using eShop.FrameWork.Infrastructure.Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddCatalogInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
        ) =>
            services
                .AddMediator(Application.AssemblyReference.Reference)
                .AddDomainRuleAdapters(Application.AssemblyReference.Reference)
                .AddDbContextPool<CatalogContext>(builder =>
                {
                    builder.UseSqlServer(configuration.GetConnectionString("Catalog"));
                });
}
