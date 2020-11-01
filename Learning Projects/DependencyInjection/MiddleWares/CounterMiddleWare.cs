using DependencyInjection.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DependencyInjection.MiddleWares
{
    public class CounterMiddleWare
    {
        private RequestDelegate _next;
        private int operations = 0; //requests counter

        public CounterMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICounter counter, CounterService counterService)
        {
            operations++;
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync($"Request: {operations}, Counter value: {counter.Value}, Service {counterService.Counter.Value}");
        }
    }
}
