using LearningWebApp.Data.Models;
using LearningWebApp.Data.Repositories.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//Rules for conventions
//1st use kebab casing for routing

namespace LearningWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Printer_Crud_APIsController : ControllerBase


        /*
            Potienal issue :
            1st: Filter is applied at memeory level using LINQ which could be less effiecint so do at DB level
            2nd: use pagination as the response could be large as well
            3rd: validate the query
         */

//*******************************************************************************************************************************************************
    {
        // GET: api/get-all-printers
        [HttpGet("get-all-printers")]
        public ActionResult<List<PrintingDistributor>> GetAllOrders(
            [FromQuery] string? Name = null,
            [FromQuery] string? Id = null,
            [FromQuery] string? PrintingSpecifications = null,
            [FromQuery] int? LocationId = null,
            [FromQuery] int? OrderCount = null
            ) // Make LocationId nullable
        {
            // Filter printers based on query parameters with AND logic
            List<PrintingDistributor> suitablePrinters = Printers.GetAllPrinters()
                .Where(v =>
                    (string.IsNullOrEmpty(Id) || v.Id == Id) &&
                    (string.IsNullOrEmpty(Name) || v.Name == Name) &&
                    (string.IsNullOrEmpty(PrintingSpecifications) || v.PrintingSpecifications == PrintingSpecifications) &&
                    (!LocationId.HasValue || v.LocationId == LocationId) && (!OrderCount.HasValue || v.OrderCount == OrderCount))
                .ToList();

            // If no printers found, return NotFound
            if (suitablePrinters.Count == 0)
            {
                return NotFound(new { message = "No vendors found for your order" });
            }

            // Return the filtered printers
            return Ok(suitablePrinters);
        }


        //*******************************************************************************************************************************************************



        //API to get a specific printer
        [HttpGet("{Id}")]
        public ActionResult<PrintingDistributor> getPDByID(String Id)
        {
            if (String.IsNullOrEmpty(Id))
            {
                return BadRequest(new { message = "Invalid ID please provide it" });
            }
            PrintingDistributor p = Printers.GetById(Id);

            return p == null ? NotFound(new { message = "No suhc foudn" }) : Ok(p);
        }

//*******************************************************************************************************************************************************

        /*
         learnings : Binding model either uses implicit binding or explicit bindling

                    implicit binding done by ASP.NET by taking the query parameter
                    explicit binding means we will tell the Framework to look where to get values

         */

        //API to create a printer
        [HttpPost("create-printer")]
        public ActionResult createPrinter([FromBody]PrintingDistributor p)
        {
            Printers.AddPrinter(p);

            return CreatedAtAction(nameof(getPDByID),new {Id = p.Id} , p);
        }


        //*******************************************************************************************************************************************************

        //API to delete a Printer
        [HttpDelete("{Id}")]
        public ActionResult DeletePrinter(string Id)
        {
            try
            {
                Printers.RemovePrinter(Id);

                return Ok(new { message = "Printer deleted successfully" });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound(new { message = "No printer found that we are trying to delet" });
            }
        }

        //*******************************************************************************************************************************************************


        //API to update a Printer
        [HttpPut("{Id}")]
        public ActionResult UpdatePrinter (string Id, PrintingDistributor p)
        {
            PrintingDistributor existingPrinter = Printers.GetById(Id);
            if(existingPrinter == null)
            {
                return BadRequest(new { message ="No printer found"});
            }
            existingPrinter.OrderCount = p.OrderCount;
            existingPrinter.Name = p.Name;
            existingPrinter.LocationId = p.LocationId;
            existingPrinter.PrintingSpecifications = p.PrintingSpecifications;

            return Ok(new { message = "Pritner updated successfully"});

        }

    }
}

