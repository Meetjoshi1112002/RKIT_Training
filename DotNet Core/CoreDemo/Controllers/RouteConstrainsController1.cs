using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{


    // Important constrains: Type (int,char,bool, string..), min, max, minlenght, maxlenght, range , lenght ,alpha(only char no number in sterin)
    //                       Regexp, required



    [Route("api/[controller]/methods")]
    [ApiController]
    public class RouteConstrainsController1 : ControllerBase
    {
        [Route("{id:int:min(0):max(20)}")]                  // we say id should be 0 - 20 adn int
        public string GetName(int id)
        {
            return "Meet"+id;
        }

        [Route("{id:range(10,20):alpha}")]                  // we say id is string and ragne length of 10-20
        public string GetNameString(int id)
        {
            return "Meet" + id;
        }

        [Route("{id:length(5):alpha}")]                  // we say id is string and length 5
        public string GetNameString2(int id)
        {
            return "Meet" + id;
        }

        [Route("{id:regex(a(b|c))}")]                  // we say it should match this regexpression
        public string GetNameRegexp(int id)
        {
            return "Regexp" + id;
        }
    }
}
