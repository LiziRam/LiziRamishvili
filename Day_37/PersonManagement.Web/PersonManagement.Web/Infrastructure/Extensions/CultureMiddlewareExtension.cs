using PersonManagement.Web.Infrastructure.Middlewares;

namespace PersonManagement.Web.Infrastructure.Extensions
{
    public static class CultureMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder app)
        {
            return app.UseMiddleware<Culturemiddleware>();
        }
    }
}
