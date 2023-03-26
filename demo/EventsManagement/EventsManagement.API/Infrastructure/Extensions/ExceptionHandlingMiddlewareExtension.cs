using EventsManagement.API.Infrastructure.Middlewares;

namespace EventsManagement.API.Infrastructure.Extensions
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
