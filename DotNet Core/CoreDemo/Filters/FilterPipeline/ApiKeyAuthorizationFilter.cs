using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreDemo.Filters.FilterPipeline
{
    public class ApiKeyAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string _apiKey;

        public ApiKeyAuthorizationFilter(string apiKey)
        {
            _apiKey = apiKey;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(!context.HttpContext.Request.Headers.TryGetValue("key",out var value))
            {
                // THis means key is not present only
                context.Result = new ObjectResult("Key is mssing")
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
                return;
            }

            string keyValue = value.ToString();

            if(!string.Equals(_apiKey,keyValue, StringComparison.OrdinalIgnoreCase))
            {
                // THis means key is unauthized
                context.Result = new ObjectResult("Invalid api key")
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
                return;
            }
        }
    }
}
