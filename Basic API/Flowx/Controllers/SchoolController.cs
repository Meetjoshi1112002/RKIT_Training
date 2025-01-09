using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend1.Controllers
{
    public class SchoolController : ApiController
    {
        // example of action method using conventinal routing config
        [HttpGet]
        public string GetMyName()
        {
            return "Meet Joshi";
        }

        [Route("api/meet/joshi/get-name")]
        [HttpGet]
        public string GetMyName2()
        {
            return "Meet Joshi using attribute routing";
        }
    }
}
