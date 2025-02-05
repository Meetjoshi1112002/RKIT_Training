using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;


/*
 * THis Filter cover the entire filter pipeline
 * 
 * Used to cache the resposne and short circuit on subsiquent request
 */

namespace Filter.Filter
{
    public class CustomResourceFilter : Attribute, IResourceFilter
    {
        private readonly IMemoryCache _cache;

        public CustomResourceFilter(IMemoryCache cache)
        {
            Console.WriteLine("Resource filter Created per request as singleton");
            _cache = cache;
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // here we will cache the response for further short cirucit
            if(context.Result is ObjectResult res && res.StatusCode == StatusCodes.Status200OK)
            {
                
                var response = JsonSerializer.Serialize(res.Value);
                _cache.Set(context.HttpContext.Request.Path.Value, response, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1000*60*5)  // basiclly 5 minutes
                });
            }
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // Create a cache key based on URL + QueryString to avoid incorrect caching
            string cacheKey = context.HttpContext.Request.Path.Value;

            if (_cache.TryGetValue(cacheKey, out string cachedData))
            {
                Console.WriteLine("Cache hit");
                // Short-circuiting the request by returning cached response
                context.Result = new ContentResult
                {
                    StatusCode = 200,
                    Content = cachedData,
                    ContentType = "application/json"
                };
            }
        }

    }
}
