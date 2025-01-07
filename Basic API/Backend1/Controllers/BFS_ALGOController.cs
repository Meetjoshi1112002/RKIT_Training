using Backend1.Models;
using Backend1.Services;
using System;
using System.Web.Http;

namespace Backend1.Controllers
{
    public class BFS_ALGOController : ApiController
    {
        [HttpPut]
        [Route("api/printer-finding-algorithm")]
        public IHttpActionResult AssignPrinter(int order_id)
        {
            try
            {
                Console.WriteLine(order_id);
                PrintingDistributor p = AssignDistributor.Assign(order_id);

                if (p == null) throw new Exception("No Printer found for your order");

                return Ok(p);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                string path = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Basic API\\Backend1\\Logger\\logs.txt";
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Exception: {ex.Message}\n";

                System.IO.File.AppendAllText(path, logMessage);
                return Content(System.Net.HttpStatusCode.NotFound, new { message = ex.Message });
            }
        }
    }
}
