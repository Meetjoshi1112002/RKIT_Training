using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Backend1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // **************************** CORS Configuration ****************************

            // Define the CORS policy
            var cors = new EnableCorsAttribute(
                origins: "*",  // Allowed origins
                headers: "*",  // Allow any headers
                methods: "*");  // Allow any methods (GET, POST, etc.)

            // Enable CORS globally
            config.EnableCors(cors);

            // ******************************************************************************
            // ************************ API Routing Configuration ***************************
            // ******************************************************************************

            // ************************** Attribute-Based Routing ***************************

            // Allows API methods to define custom routes using [Route] attributes.
            // Example: [Route("api/products")] must be added to each action method.
            // This approach is flexible but may be cumbersome for large projects.
            config.MapHttpAttributeRoutes();

            // ************************ Convention-Based Routing ****************************

            // Defines a conventional route structure where the URL pattern automatically maps to controllers.
            // This is NOT required here since attribute routing is used for all APIs.
            /*
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            */

            // *************************** Custom Routing Templates ************************

            // Custom template for API versioning: /v1/api/{controller}/{id}
            // Example: If a "MeetController" exists, /v1/api/Meet will automatically map to it.
            config.Routes.MapHttpRoute(
                name: "MyCustomTemplate",
                routeTemplate: "v1/api/{controller}/{id}",
                defaults: new { controller = "School", id = RouteParameter.Optional },
                constraints: new { id = @"\d+" } // Ensures 'id' is a digit if provided
            );

            // *************************** Versioned API Routing ****************************

            // Older version of "Get All Orders" API without query parameters
            // This maps all actions inside "SchoolController" under version v0.
            config.Routes.MapHttpRoute(
                name: "Version0",
                routeTemplate: "v0/api/School/{action}",
                defaults: new { controller = "School" }
            );
        }
    }
}
