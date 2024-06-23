using pdksApi.Core.Utilities.Middleware;
using Microsoft.AspNetCore.Builder;

namespace pdksApi.Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
