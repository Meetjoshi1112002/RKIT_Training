using LearningWebApp.Data.Models;
using LearningWebApp.Data.Repositories.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet("getAllOrders")]
        public ActionResult<List<PrintingDistributor>> GetAllOrders()
        {
            return Ok(Printers.GetAllPrinters());
        }
    }
}
