using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter.Filter
{
    public class CustomResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("The Result filter ended");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            // we will just set some header here to show usage
            context.HttpContext.Response.Headers.Add("HeadersFrom", "Meet joshi");
            Console.WriteLine("Resutl filter started");
        }
    }
}
