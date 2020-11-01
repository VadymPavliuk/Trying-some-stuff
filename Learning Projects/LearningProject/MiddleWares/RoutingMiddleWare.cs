using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LearningProject.MiddleWares
{
    public class RoutingMiddleWare
    {
        private readonly RequestDelegate _next;

        public RoutingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value;
            if (path == "/index")
            {
                await context.Response.WriteAsync("Got to indext page");
            }
            if (path == "/about")
            {
                await context.Response.WriteAsync("Go to about page");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }
    }
}
