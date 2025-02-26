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
        /// <summary>
        /// Retrieves all printers with optional filtering criteria.
        /// </summary>
        /// <param name="Name">Filter by printer name (optional).</param>
        /// <param name="Id">Filter by printer ID (optional).</param>
        /// <param name="PrintingSpecifications">Filter by printing specifications (optional).</param>
        /// <param name="LocationId">Filter by location ID (optional).</param>
        /// <param name="OrderCount">Filter by order count (optional).</param>
        /// <returns>List of printers matching the criteria.</returns>
        [HttpGet]
        [Route("api/get-all-printers")]
        public IHttpActionResult GetAllPrinters(string Name = null, string Id = null, string PrintingSpecifications = null, int? LocationId = null, int? OrderCount = null)
        {
            try
            {
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
                LogException(ex);
                return Content(System.Net.HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves a specific printer by ID.
        /// </summary>
        /// <param name="Id">The ID of the printer.</param>
        /// <returns>The printer object if found; otherwise, NotFound.</returns>
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

        /// <summary>
        /// Creates a new printer.
        /// </summary>
        /// <param name="printer">The printer object to create.</param>
        /// <returns>The created printer with its ID.</returns>
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

        /// <summary>
        /// Deletes a printer by ID.
        /// </summary>
        /// <param name="Id">The ID of the printer to delete.</param>
        /// <returns>Success message if deletion is successful.</returns>
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
                LogException(ex);
                return Content(System.Net.HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Updates an existing printer by ID.
        /// </summary>
        /// <param name="Id">The ID of the printer to update.</param>
        /// <param name="updatedPrinter">The updated printer object.</param>
        /// <returns>Success message if update is successful.</returns>
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

        /// <summary>
        /// Logs exceptions to a log file.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        private void LogException(Exception ex)
        {
            string path = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Basic API\\Backend1\\Logger\\logs.txt";
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Exception: {ex.Message}\n";
            System.IO.File.AppendAllText(path, logMessage);
        }
    }
}
