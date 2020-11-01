using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LearningProject.MiddleWares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
            if (context.Response.StatusCode == 403)
            {
                await context.Response.WriteAsync("User have no access");
            }
            if(context.Response.StatusCode == 404)
            {
                await context.Response.WriteAsync("Page not found");
            }
        }
    }
}
