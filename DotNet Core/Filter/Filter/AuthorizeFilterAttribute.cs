using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter.Filter
{
    public class AuthorizeFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _apiKey;

        /// <summary>
        /// Initializes a new instance of the AuthorizeFilterAttribute class with the specified API key.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public AuthorizeFilterAttribute(string apiKey)
        {
            _apiKey = apiKey;
        }

        /// <summary>
        /// Called when authorization is required.
        /// </summary>
        /// <param name="context">The authorization filter context.</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("My-API-Key", out var apiKeyHeaders))
            {
                context.Result = new ObjectResult("API key is missing")
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
                return;
            }

            string apiKey = apiKeyHeaders.ToString();
            if (!string.Equals(apiKey, _apiKey))
            {
                context.Result = new ObjectResult("Invalid API key")
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
                return;
            }
        }
    }
}
