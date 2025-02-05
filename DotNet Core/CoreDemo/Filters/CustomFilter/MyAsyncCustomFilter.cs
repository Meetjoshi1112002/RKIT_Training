using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreDemo.Filters.CustomFilter
{
    public class MyAsyncCustomFilter : Attribute, IAsyncActionFilter
    {
        private readonly string _name;
        public MyAsyncCustomFilter(string name)
        {
            _name = name;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("Before world");
            await next();
            Console.WriteLine("After world");
        }
    }
}
