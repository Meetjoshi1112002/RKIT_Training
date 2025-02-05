using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreDemo.Filters.CustomFilter
{
    public class MyCustomFilter : Attribute, IActionFilter
    {
        private readonly string _name;
        public MyCustomFilter(string name)
        {
            _name = name;
        }
        public void OnActionExecuted(ActionExecutedContext context)   // This will run after the request leaves the request pipleing
        {
            Console.WriteLine($"Filter exit - {_name}");
        }

        public void OnActionExecuting(ActionExecutingContext context) // This will run when the request enters the request pipleing
        {
            Console.WriteLine($"Filter Entered - {_name}");
        }
    }
}
