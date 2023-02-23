using System;
using Todo.API.Infrastructure.Middlewares;

namespace Todo.API.Infrastructure.Extensions
{
    public static class ExceptionHandlingMiddlewareExtension
    {
        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandlingMiddleware>();
            return builder;
        }
    }
}

