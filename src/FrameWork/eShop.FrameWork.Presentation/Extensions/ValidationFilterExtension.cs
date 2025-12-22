using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace eShop.FrameWork.Presentation.Extensions;

public static class ValidationFilterExtension
{
    public static RouteHandlerBuilder Validate<TRequest>(this RouteHandlerBuilder builder)
    {
        builder.AddEndpointFilter<EndpointValidationFilter<TRequest>>();

        return builder;
    }
}
