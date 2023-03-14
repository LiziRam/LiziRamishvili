using System;
using Todo.API.Infrastructure.Middlewares;

namespace Todo.API.Infrastructure.Extensions
{
    public static class RequestResponseLoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestResponseMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<RequestResponseLoggingMiddleware>();
            return builder;
        }
    }
}

