using Swashbuckle.Application;
using System.Web.Http;

using System.Web.Http.Cors;

namespace Backend1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config) // --> basic pipline
        {
            //CORS
            //config.EnableCors(); // this is like *

            //config.EnableCors(new EnableCorsAttribute("orgin", "headers", "mehtods"));  // we we add our custom policy


            // Web API configuration and services

            // Web API routes

            // Attribute based routing ******************************
            // If you want this then if all action methods you will have to write the route attribute 
            // ie [Route("api/products")] on every action method
            // This is cumber some for large projects
            config.MapHttpAttributeRoutes();



            // Convention based routing ****************************

            // Here not required as I have done attribuute routring in all my apis
            //config.Routes.MapHttpRoute(
              //  name: "DefaultApi",
               // routeTemplate: "api/{controller}/{id}",
                //defaults: new { id = RouteParameter.Optional }
            //);


            // This is my custom template
            // if there is one MeetController made then url like /vi/api/Meet will map there automatically
            config.Routes.MapHttpRoute(
                name:"MyCustomTemplate",
                routeTemplate:"v1/api/{controller}/{id}",
                defaults:new {controller="School", id = RouteParameter.Optional },
                constraints:new {id = "/d+"}  // tells that optional parameter id must only ve a dighti
            );

            // old version of get all orders with no query providers
            config.Routes.MapHttpRoute(
                name:"Version0",
                routeTemplate:"v0/api/School/{action}",
                defaults: new { controller = "School"}    
            );


            //// configuring swagger:
            //// Enable Swagger and Swagger UI
            //config
            //    .EnableSwagger(c =>
            //    {
            //        c.SingleApiVersion("v1", "Flowx")
            //         .Description("Smart APIs to automate orders generation and printer assign using BFS")
            //         .Contact(cc => cc
            //             .Name("Meet Joshi")
            //             .Email("meetjoshi1112002@gmail.com"));

            //    })
            //    .EnableSwaggerUi();
        }
    }
}
