using System;
using PizzaRestaurant.API.Infrastructure.Middlewares;

namespace PizzaRestaurant.API.Infrastructure.Extensions
{
	public static class RequestResponseMiddlewareExtension
	{
        public static IApplicationBuilder UserRequestResponseMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<RequestResponseMiddleware>();
            return builder;
        }
    }
}

