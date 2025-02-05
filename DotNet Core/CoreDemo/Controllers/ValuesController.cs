using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]                        // Base url
    public class ValuesController : ControllerBase
    {
        
        [Route("get-name")]                                 // append to base url liek : values/getName/get-name
        [Route("get-name/v2")]                              // same resource multiple urls
        public string GetName()
        {
            return "Meet joshi";
        }

        [Route("~/overwite/{id}")]                               //we Overwrite the base url
        public string GetMyName(int id)
        {
            return "Meet Josh i"+id;
        }
    }
}
