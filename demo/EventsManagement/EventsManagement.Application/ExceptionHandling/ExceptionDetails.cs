using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsManagement.Application.ExceptionHandling
{
    public class ExceptionDetails : ProblemDetails
    {
        private Exception _exception;
        private HttpContext _httpContext;

        public ExceptionDetails(HttpContext context, Exception ex)
        {
            _httpContext = context;
            _exception = ex;

            TraceId = context.TraceIdentifier;
            Status = (int)HttpStatusCode.InternalServerError;

            HandleException((dynamic)ex);
        }

        public string TraceId
        {
            get
            {
                if (Extensions.TryGetValue("TraceId", out var traceId)) return (string)traceId;

                return null;
            }
            set => Extensions["TraceId"] = value;
        }

        private void HandleException(dynamic exception)
        {
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
            Title = exception.Message;
        }
    }
}
