using CoreDemo.Middleware;
using CoreDemo.Filters.CustomFilter;
using CoreDemo.Extension;

namespace CoreDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add controller services
            
            services.AddControllers(option =>
            {
                option.Filters.Add(new MyCustomFilter("Global filter"));       //Adding our filter to controller at golbal level
            }); 
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<DemoMiddleware1>();


            // Add all DI here for clean coding
            services.AddServicesToContainer();

            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //// Middleware 1
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Middle - 1 1\n");

            //    await next();


            //    await context.Response.WriteAsync("Middle - 1 2\n");
            //});

            //app.UseMiddleware<DemoMiddleware1>();

            //// Map branch for specific URLs
            //app.Map("/specific-urls", CustomCode);

            //// Middleware 2
            //app.Use(async (context, next) =>
            //{
            //        await context.Response.WriteAsync("Middle - 2 1\n");

            //    await next();
            //        if(!context.Response.HasStarted)
            //        await context.Response.WriteAsync("Middle - 2 2\n");
            //});

            app.UseEndpoints(endpoints =>
            {
                // Conventional routing for controllers like "values" (without attribute routes)
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{action}/{id?}",
                    defaults:new {controller = "Values"}
                );
                endpoints.MapControllers(); // Map controller endpoints (attribute routing for orhters)
            });

            // Terminate the pipeline
            app.Run(async context =>
            {
                await context.Response.WriteAsync("run middleware has no next and represents end of pipeline\n");
            });
        }

        private void CustomCode(IApplicationBuilder app)
        {
            // Handle the request for /specific-urls
            app.Run(async context =>
            {
                    await context.Response.WriteAsync("Reached here for admin\n");
            });
        }
    }
}
