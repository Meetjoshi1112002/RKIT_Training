using Microsoft.AspNetCore.Mvc.Filters;
using MiddleWares.Middleware;

namespace MiddleWares
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //registyer our custom middleware
            services.AddScoped<MyCustomMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // All configuration of pipeline is done here (filter and Middleware)
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseRouting(); // Add this line to enable routing

            app.UseAuthorization();

            // Adding Middleware 1
            app.Use(async (context, next) =>
            {
                Console.WriteLine("Middleware 1: Before");
                await next(); // Passes control to the next middleware
                Console.WriteLine("Middleware 1: After");
            });

            app.Map("/admin", appHandler);

            app.UseMiddleware<MyCustomMiddleware>();

            //This is a terminal middleware
            //app.UseEndpoints() ;

            // If we dont pass the request to next segment( ie next delegate) it is basically short circuted)
            app.Run(async (contxt) =>
            {
                await contxt.Response.WriteAsync("Never executed as UseEndpoints is a termaila middleware");
                
            });
        }

        private void appHandler(IApplicationBuilder obj)
        {
            // we can create sub brach as well

            obj.Use(async (context, next) =>
            {
                Console.WriteLine("Middleware 1 for admin: Before");
                await next(); // Passes control to the next middleware
                Console.WriteLine("Middleware 1 for admin End : After");
            });

            obj.Run(async (contex) =>
            {
                await contex.Response.WriteAsync("End for admin piplein");
            });
        }
    }
}
