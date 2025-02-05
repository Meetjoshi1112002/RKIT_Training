using CoreDemo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreDemo.Filters.CustomFilter;
using CoreDemo.Filters;

namespace CoreDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [MyCustomFilter("Filter at controller level")]
    public class DIController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public DIController(IUserRepo userRepo)             // THis is called resolving DI in constructor only
        {                                                   // We can get multiple ref as well form construtor
            _userRepo = userRepo;                           // Wheater it same or unique instance depends on service type(scoped, transient ..etc)
        }   


        [HttpGet] // relative routing
        [MyAsyncCustomFilter("Filter at route level")]
        public IActionResult GetAllUser([FromServices] IUserRepo _userr) 
        {
            Console.WriteLine("HI");
            return Ok(_userr.GetAll());
        }

        [HttpPost("user")] // realteive routing
        public IActionResult AddUser(User user)
        {
            _userRepo.AddUser(user);
            List<User> users = _userRepo.GetAll();
            return Ok(users);
        }
    }
}
