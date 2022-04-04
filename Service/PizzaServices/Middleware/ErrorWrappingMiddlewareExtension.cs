using Microsoft.AspNetCore.Builder;

namespace PizzaStoreManagement.API.Middleware
{
    public static class ErrorWrappingMiddlewareExtension
    {
        public static IApplicationBuilder UseErrorWrappingMiddleware(this ApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ErrorWrappingMiddleware>();
        }
    }
}
