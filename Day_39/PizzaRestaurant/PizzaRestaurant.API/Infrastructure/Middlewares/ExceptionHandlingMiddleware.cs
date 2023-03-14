using System;
using System.Net;
using Newtonsoft.Json;
using PizzaRestaurant.Application.ExceptionHandling;

namespace PizzaRestaurant.API.Infrastructure.Middlewares
{
	public class ExceptionHandlingMiddleware
	{
        private const string path = @"/Users/liziramishvili/Desktop/LiziRamishvili/Day_40/PizzaRestaurant/PizzaRestaurant.API/LogExceptions.txt";

        private readonly RequestDelegate _next;

		public ExceptionHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch(Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var error = new ExceptionDetails(context, ex);
            var result = JsonConvert.SerializeObject(error);

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            //context.Response.StatusCode = error.Status.Value;

            await LogException(ex);

            await context.Response.WriteAsync(result);
        }

        private async Task LogException(Exception ex)
        {
            var toLog = $"Message: {ex.Message} \nSource: {ex.Source} \nStackTrace: {ex.StackTrace} \n\n";
            await File.AppendAllTextAsync(path, toLog);
        }
    }
}


