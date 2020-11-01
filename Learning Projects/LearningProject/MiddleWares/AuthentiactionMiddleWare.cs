using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LearningProject.MiddleWares
{
    public class AuthentiactionMiddleWare
    {
        private readonly RequestDelegate _next;

        public AuthentiactionMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["Token"];
            if (string.IsNullOrWhiteSpace(token))
            {
                context.Response.StatusCode = 403;
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
