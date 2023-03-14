
using System;
using PizzaRestaurant.API.Infrastructure.Middlewares;

namespace PizzaRestaurant.API.Infrastructure.Extensions
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

