using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LearningProject.MiddleWares
{
    public class TokenMiddleWare
    {
        private readonly RequestDelegate _next;

        public TokenMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["Token"];
            if (token != "12345678")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token invalid");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
