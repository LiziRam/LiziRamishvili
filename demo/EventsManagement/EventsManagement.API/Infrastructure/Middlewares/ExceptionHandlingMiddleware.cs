using EventsManagement.Application.ExceptionHandling;
using Newtonsoft.Json;

namespace EventsManagement.API.Infrastructure.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private const string path =
            @"/Users/liziramishvili/Desktop/demo/EventsManagement/EventsManagement.API/LogExceptions.txt";

        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var error = new ExceptionDetails(context, ex);
            var result = JsonConvert.SerializeObject(error);

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = error.Status.Value;

            await LogException(ex).ConfigureAwait(false);

            await context.Response.WriteAsync(result).ConfigureAwait(false);
        }

        private async Task LogException(Exception ex)
        {
            var toLog = $"Message: {ex.Message} \nSource: {ex.Source} \nStackTrace: {ex.StackTrace} \n\n";
            await File.AppendAllTextAsync(path, toLog).ConfigureAwait(false);
        }
    }
}
