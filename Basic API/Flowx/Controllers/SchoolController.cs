using Backend1.Repository;
using System.Web.Http;

namespace Backend1.Controllers
{
    public class SchoolController : ApiController
    {
        // old versoitn of get all orders

        [HttpGet]
        public IHttpActionResult GetAllOrders()
        {
            return Ok(OrdersRepo.GetAllOrder());
        }
        // example of action method using conventinal routing config
        [HttpDelete]
        void  DeleteMyName()
        {
            //Delete something so 204 No context
        }

        [Route("api/meet/joshi/get-name")]
        [HttpGet]
        public string GetMyName2()
        {
            return "Meet Joshi using attribute routing";
        }
    }
}
