/*
 * We can also create a class ,but then need to create delegate and context prperty and set in constructor
 * 
 * This is more simplified
 */


namespace MiddleWares.Middleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("in my Custom middleware entry for " + context.Request.Path.Value);
            await next(context);
            await Console.Out.WriteLineAsync("exit from custom middlewar for " + context.Request.Path.Value);
        }
    }
}
