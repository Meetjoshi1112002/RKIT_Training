using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter.Filter
{
    public class CustomActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Entered here in action filter");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Exite here in aciton fitler");
        }
    }
}
