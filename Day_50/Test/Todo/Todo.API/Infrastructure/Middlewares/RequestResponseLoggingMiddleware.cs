using System;
using System.Text;

namespace Todo.API.Infrastructure.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private const string path = @"C:\Users\lizi\Desktop\Test\Todo\Todo.API\LogRequestResponse.txt";

        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Stream originalBody = context.Response.Body;
            string responseBody = "";
            try
            {
                await LogRequestInformation(context.Request);

                using (var memStream = new MemoryStream())
                {
                    context.Response.Body = memStream;

                    await _next(context);

                    memStream.Position = 0;
                    responseBody = new StreamReader(memStream).ReadToEnd();

                    memStream.Position = 0;
                    await memStream.CopyToAsync(originalBody);
                }
            }
            finally
            {
                context.Response.Body = originalBody;
                await LogResponseInformation(context.Response, responseBody);
            }
        }

        private async Task LogRequestInformation(HttpRequest request)
        {
            var Body = await ReadRequestBody(request);

            var logText = $"REQUEST INFORMATION: \n" +
                        $"IP = {request.HttpContext.Connection.RemoteIpAddress.ToString()}{Environment.NewLine}" +
                        $"Address = {request.Scheme}{Environment.NewLine}" +
                        $"Method = {request.Method}{Environment.NewLine}" +
                        $"Path = {request.Path}{Environment.NewLine}" +
                        $"IsSecured = {request.IsHttps.ToString()}{Environment.NewLine}" +
                        $"QueryString = {request.QueryString.ToString()}{Environment.NewLine}" +
                        $"RequestBody = {Body}{Environment.NewLine}" +
                        $"Time = {DateTime.Now.ToString()}{Environment.NewLine}";
            await File.AppendAllTextAsync(path, logText);
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableBuffering();

            var buffer = new byte[request.ContentLength ?? 0];

            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body.Position = 0;

            return bodyAsText;
        }


        private async Task LogResponseInformation(HttpResponse response, string responseBody)
        {
            var logText = $"RESPONSE INFORMATION: \n" +
                        $"ResponseBody = {responseBody}{Environment.NewLine}" +
                        $"Time = {DateTime.Now.ToString()}{Environment.NewLine}";
            await File.AppendAllTextAsync(path, logText);
        }

    }
}

