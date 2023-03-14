using System;
using PizzaRestaurant.API.Infrastructure.Middlewares;

namespace PizzaRestaurant.API.Infrastructure.Extensions
{
	public static class CultureMiddlewareExtension
	{
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CultureMiddleware>();
        }
    }
}

