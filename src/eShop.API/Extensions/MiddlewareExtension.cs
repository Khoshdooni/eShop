using eShop.FrameWork.Presentation.Extensions;
using Scalar.AspNetCore;

namespace eShop.API.Extensions;

public static class MiddlewareExtension
{
    public static void UseMiddlewares(this WebApplication app)
    {
        app.UseExceptionHandler();

        if (app.Environment.IsDevelopment())
        {
            // app.MapOpenApi();
            app.MapScalarApiReference();
            app.MapGet("/", () => Results.Redirect("/scalar")).WithTags("Root");
        }

        app.MapEndpoints();
        app.UseCors();
    }
}
