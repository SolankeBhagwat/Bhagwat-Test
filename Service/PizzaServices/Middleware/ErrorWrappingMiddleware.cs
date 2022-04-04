using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace PizzaStoreManagement.API.Middleware
{
    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorWrappingMiddleware> _logger;
        public ErrorWrappingMiddleware(RequestDelegate next, ILogger<ErrorWrappingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception exception)
            {
                var errorGuid= Guid.NewGuid();
                var logMessage = $@"Unhandled exption was throw!{Environment.NewLine}
                                    Exception Guid:{errorGuid}{Environment.NewLine}
                                    ExceptionMessage:{exception.Message}";
                _logger.LogError(logMessage);

                httpContext.Response.Clear();
                httpContext.Response.StatusCode = 400;

                var userFriendlyMessage = $"There was an unexpected error, Please use following ID to contact us: {errorGuid}";
                var serviceMessage = new
                {
                    Errors = userFriendlyMessage,
                    StatusCode = 400
                };
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(serviceMessage));
            }

        } 
    }
}
