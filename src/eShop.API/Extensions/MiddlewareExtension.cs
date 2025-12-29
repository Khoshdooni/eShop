using eShop.FrameWork.Presentation.Extensions;

namespace eShop.API.Extensions;

public static class MiddlewareExtension
{
    public static void UseMiddlewares(this WebApplication app)
    {
        app.UseExceptionHandler();

        if (app.Environment.IsDevelopment())
        {
            //app.MapOpenApi();
            app.MapGet("/", () => Results.Redirect("/swagger")).WithTags("Root");
        }

        app.MapEndpoints();
        app.UseCors();
    }
}
