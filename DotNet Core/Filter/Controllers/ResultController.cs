using Filter.Filter;
using Microsoft.AspNetCore.Mvc;

namespace Filter.Controllers
{
    public class User
    {
        public string Name { get; set; }

        public string Roll { get; set; }
    }



    [Route("api/[controller]")]
    [ApiController]
    [CustomResultFilter]
    [CustomActionFilter]
    public class ResultController : ControllerBase
    {
        private readonly List<User> _user = new() 
        {
            new User(){Name="Meet",Roll="21CP024"},
            new User(){Name="Neet",Roll="21CP014"},
            new User(){Name="Reet",Roll="21CP004"}
        };
        [HttpGet]
        [ServiceFilter(typeof(CustomResourceFilter))]
        [AuthorizeFilter("Ro-Hitman-Sharma")]
        public IActionResult GetAll()
        {
            
            return Ok(_user);
        }
    }
}
