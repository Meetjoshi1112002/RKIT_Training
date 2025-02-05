namespace CoreDemo.Middleware
{
    public class DemoMiddleware1 : IMiddleware
    {
        async public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Helo from file\n");
            await next(context);
            await context.Response.WriteAsync("Bye from file\n");
        }
    }
}
