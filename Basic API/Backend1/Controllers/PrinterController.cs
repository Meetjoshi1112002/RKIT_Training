using Backend1.Models;
using Backend1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Backend1.Controllers
{
    public class PrinterController : ApiController
    {
        // GET: api/get-all-printers
        [HttpGet]
        [Route("api/get-all-printers")] // Ensure this matches the WebApiConfig
        public IHttpActionResult GetAllPrinters(string Name = null, string Id = null, string PrintingSpecifications = null, int? LocationId = null, int? OrderCount = null)
        {
            try
            {
                // Filter Printers based on query parameters with AND logic
                List<PrintingDistributor> suitablePrinters = Printers.GetAllPrinters()
                    .Where(v =>
                        (string.IsNullOrEmpty(Id) || v.Id == Id) &&
                        (string.IsNullOrEmpty(Name) || v.Name == Name) &&
                        (string.IsNullOrEmpty(PrintingSpecifications) || v.PrintingSpecifications == PrintingSpecifications) &&
                        (!LocationId.HasValue || v.LocationId == LocationId) &&
                        (!OrderCount.HasValue || v.OrderCount == OrderCount))
                    .ToList();

                if (!suitablePrinters.Any())
                {
                    return NotFound();
                }

                return Ok(suitablePrinters);
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

        // GET: api/printers/{Id}
        [HttpGet]
        [Route("api/printers/{Id}")]
        public IHttpActionResult GetPrinterById(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return BadRequest("Invalid ID. Please provide a valid one.");
            }

            PrintingDistributor printer = Printers.GetById(Id);
            if (printer == null)
            {
                return NotFound();
            }

            return Ok(printer);
        }

        // POST: api/create-printer
        [HttpPost]
        [Route("api/create-printer")]
        public IHttpActionResult CreatePrinter([FromBody] PrintingDistributor printer)
        {
            if (printer == null)
            {
                return BadRequest("Printer cannot be null.");
            }

            Printers.AddPrinter(printer);

            return Created($"api/printers/{printer.Id}", printer);
        }

        // DELETE: api/printers/{Id}
        [HttpDelete]
        [Route("api/printers/{Id}")]
        public IHttpActionResult DeletePrinter(string Id)
        {
            try
            {
                Printers.RemovePrinter(Id);

                return Ok(new { message = "Printer deleted successfully." });
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

        // PUT: api/printers/{Id}
        [HttpPut]
        [Route("api/printers/{Id}")]
        public IHttpActionResult UpdatePrinter(string Id, [FromBody] PrintingDistributor updatedPrinter)
        {
            if (updatedPrinter == null)
            {
                return BadRequest("Printer data cannot be null.");
            }

            PrintingDistributor existingPrinter = Printers.GetById(Id);
            if (existingPrinter == null)
            {
                return NotFound();
            }

            existingPrinter.Name = updatedPrinter.Name;
            existingPrinter.LocationId = updatedPrinter.LocationId;
            existingPrinter.PrintingSpecifications = updatedPrinter.PrintingSpecifications;
            existingPrinter.OrderCount = updatedPrinter.OrderCount;

            return Ok(new { message = "Printer updated successfully." });
        }
    }
}
