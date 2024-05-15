using Microsoft.AspNetCore.Builder;

using SideKick.Infrastructure.Common.Middleware;

namespace SideKick.Infrastructure;

public static class RequestPipeline
{
    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseMiddleware<EventualConsistencyMiddleware>();
        return app;
    }
}