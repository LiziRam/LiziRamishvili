using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PizzaRestaurant.Application.ExceptionHandling
{
	public class ExceptionDetails : ProblemDetails
	{
        private HttpContext _httpContext;
        private Exception _exception;

        public string TraceId
        {
            get
            {
                if (Extensions.TryGetValue("TraceId", out var traceId))
                {
                    return (string)traceId;
                }

                return null;
            }
            set => Extensions["TraceId"] = value;
        }

        public ExceptionDetails(HttpContext context, Exception ex)
		{
            _httpContext = context;
            _exception = ex;

            TraceId = context.TraceIdentifier;
            Status = (int)HttpStatusCode.InternalServerError;
            
            HandleException((dynamic)ex);
        }

        private void HandleException(dynamic exception)
        {
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
            Title = exception.Message;
        }
    }
}

