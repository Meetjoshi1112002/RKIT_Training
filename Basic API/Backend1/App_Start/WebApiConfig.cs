using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Backend1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config) // --> basic pipline
        {
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
        }
    }
}
