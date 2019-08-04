using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace webapi.Middleware
{
    public class CorrelationMiddleware
    {
        private readonly RequestDelegate _next;
        private static string CorrelationHeader = "X-Correlation-Id"; 

        public CorrelationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var correlationHeader = context.Request.Headers
                .FirstOrDefault(x => x.Key.Equals(CorrelationHeader, StringComparison.InvariantCultureIgnoreCase));

            var correlationId = string.IsNullOrWhiteSpace(correlationHeader.Value)
                    ? Guid.NewGuid().ToString()
                    : correlationHeader.Value.ToString();

            if (string.IsNullOrWhiteSpace(correlationHeader.Value))
            {
                context.Request.Headers.Add(CorrelationHeader, correlationId);
            }

            await _next(context);

            context.Response.Headers.Add(CorrelationHeader, correlationId);
        }
    }
}
