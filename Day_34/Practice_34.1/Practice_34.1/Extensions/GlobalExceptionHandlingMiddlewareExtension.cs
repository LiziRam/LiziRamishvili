using System;
using Practice_34._1.Middlewares;

namespace Practice_34._1.Extensions
{
	public static class GlobalExceptionHandlingMiddlewareExtension
	{
		public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder builder)
		{
			builder.UseMiddleware<GlobalExceptionHandlingMiddleware>();
			return builder;
		}
	}
}

