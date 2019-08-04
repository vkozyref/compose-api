using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace webapi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                context.Response.StatusCode = 500;
            }
            
        }
    }
}
