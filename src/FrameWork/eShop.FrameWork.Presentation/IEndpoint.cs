using Microsoft.AspNetCore.Routing;

namespace eShop.FrameWork.Presentation;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder builder);
}
