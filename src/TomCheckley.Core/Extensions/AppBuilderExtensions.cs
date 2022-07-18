using Microsoft.AspNetCore.Builder;
using TomCheckley.Core.Middleware;

namespace TomCheckley.Core.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder AddCustomHttpHeaders(this IApplicationBuilder application)
        {
            return application.UseMiddleware<CustomHttpHeadersMiddleware>();
        }
    }
}
