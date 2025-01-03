using LearningWebApp.Data.Models;
using LearningWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace LearningWebApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BFS_Algorythms:ControllerBase
    {
        [HttpPut("printer-finding-algorythm")]
        public ActionResult AssignPrinter(int order_id)
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
                string path = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Basic API\\LearningWebApp\\Logging\\logs.txt";
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Exception: {ex.Message}\n";

                System.IO.File.AppendAllText(path, logMessage); // becasuse it got ambiguid by ControllerBase.file
                return NotFound(new {messsage = ex.Message});

            }
        }

    }
}
