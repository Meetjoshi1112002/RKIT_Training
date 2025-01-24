using ServiceStack.OrmLite;
using System.Configuration;
using System.Web.Http;

namespace FinalDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
