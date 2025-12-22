
namespace eShop.API;

public static class ServiceExtension
{
    public static void AddServices(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment env
    )
    {
        services
            .AddOpenApi()
            .AddExceptionHandler<GlobalExceptionHandler>()
            .AddProblemDetails()
            .AddCatalogServices(configuration)
            //.AddSecurityServices(configuration, Security.Presentation.AssemblyReference.Reference)
            .AddCors(setup =>
            {
                setup.AddDefaultPolicy(policy =>
                {
                    if (env.IsDevelopment())
                    {
                        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    }
                    else
                    {
                        policy
                            .WithOrigins("domain1")
                            .WithMethods("GET,POST,DELETE")
                            .WithHeaders("");
                        policy.WithOrigins("domain2").WithMethods("GET").WithHeaders("");
                    }
                });
            });
    }
}
