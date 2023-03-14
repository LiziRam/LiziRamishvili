using System;
using System.Net;

namespace Practice_34._1.Middlewares
{
	public class GlobalExceptionHandlingMiddleware
	{
		public static string path = @"/Users/liziramishvili/Desktop/LiziRamishvili/Day_34/Practice_34.1/Practice_34.1/LogExceptions.txt";

        private readonly RequestDelegate _next;

		public GlobalExceptionHandlingMiddleware(RequestDelegate next)
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
				await LogException(ex);
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			}
		}

        private async Task LogException(Exception ex)
        {
			var toLog = $"Message: {ex.Message} \nSource: {ex.Source} \nStackTrace: {ex.StackTrace} \n\n";
			await File.AppendAllTextAsync(path, toLog);
        }
    }
}

