using LearningProject.MiddleWares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LearningProject
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
            //var options = new DefaultFilesOptions();
            //options.DefaultFileNames.Add("Hello.html");
            //app.UseDefaultFiles(options);
            app.UseDirectoryBrowser();
            app.UseStaticFiles();
            

            //app.UseMiddleware<ErrorHandlingMiddleware>();
            //app.UseMiddleware<AuthentiactionMiddleWare>();
            //app.UseMiddleware<RoutingMiddleWare>();
            //app.UseMiddleware<TokenMiddleWare>();

            app.Map("/page", PageOpen);

            app.MapWhen(context => { return context.Request.Query.ContainsKey("id"); }, ConditionPage);

            app.Map("/basePage", basePage =>
            {
                basePage.Map("/page", PageOpen);
                basePage.Map("/about", About);
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

        }

        private void ConditionPage(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("You have id on the route");
            });
        }

        private void PageOpen(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Page opens");
            });
        }

        private void About(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("about opens");
            });
        }
    }
}
