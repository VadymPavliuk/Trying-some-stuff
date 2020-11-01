using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RoutingAPp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.Use(async (context, next) => {
                Endpoint endpoint = context.GetEndpoint();

                if (endpoint != null)
                {
                    var routePattern = (endpoint as Microsoft.AspNetCore.Routing.RouteEndpoint)?.RoutePattern?.RawText;
                    Debug.Write($"Endpoint Name: {endpoint.DisplayName}" + Environment.NewLine);
                    Debug.Write($"Endpoint Pattern: {routePattern}" + Environment.NewLine);

                    await next();
                }
                else
                {
                    Debug.Write($"Endpoint: null ");
                    await context.Response.WriteAsync("Endpoint is not defined" + Environment.NewLine);
                }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/index", async context =>
                {
                    await context.Response.WriteAsync("Hello Index!");
                });
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
