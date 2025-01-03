using LearningWebApp.Data.Models;
using LearningWebApp.Data.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LearningWebApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class Order_Crud_APIsController:ControllerBase
    {
        // GET: api/get-all-orders
        [HttpGet("get-all-orders")]
        public ActionResult<List<Order>> GetAllOrders(
            [FromQuery] string? Name = null,
            [FromQuery] int? Id = null,
            [FromQuery] string? PrintingSpecifications = null,
            [FromQuery] int? LocationId = null
            ) // Make LocationId nullable
        {
            // Filter OrdersRepo based on query parameters with AND logic
            List<Order> suitableOrder = OrdersRepo.GetAllOrder()
                .Where(v =>
                    (!Id.HasValue || v.Id == Id) &&
                    (string.IsNullOrEmpty(Name) || v.Name == Name) &&
                    (string.IsNullOrEmpty(PrintingSpecifications) || v.PrintingSpecifications == PrintingSpecifications) &&
                    (!LocationId.HasValue || v.LocationId == LocationId)
                    ).ToList();

            // If no OrdersRepo found, return NotFound
            if (suitableOrder.Count == 0)
            {
                return NotFound(new { message = "No Orderrs found" });
            }

            // Return the filtered OrdersRepo
            return Ok(suitableOrder);
        }


        //*******************************************************************************************************************************************************



        //API to get a specific Order
        [HttpGet("{Id}")]
        public ActionResult<Order> getPDByID(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest(new { message = "Invalid ID please provide it" });
            }
            Order p = OrdersRepo.GetOrderById(Id);

            return p == null ? NotFound(new { message = "No suhc foudn" }) : Ok(p);
        }

        //*******************************************************************************************************************************************************

        //API to create a Order
        [HttpPost("create-Order")]
        public ActionResult createOrder([FromBody] Order p)
        {
            OrdersRepo.AddOrder(p);

            return CreatedAtAction(nameof(getPDByID), new { Id = p.Id }, p);
        }


        //*******************************************************************************************************************************************************

        //API to delete a Order
        [HttpDelete("{Id}")]
        public ActionResult DeleteOrder(int Id)
        {
            try
            {
                OrdersRepo.RemoveOrder(Id);

                return Ok(new { message = "Order deleted successfully" });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound(new { message = "No Order found that we are trying to delet" });
            }
        }

        //*******************************************************************************************************************************************************


        //API to update a Order
        [HttpPut("{Id}")]
        public ActionResult UpdateOrder(int Id, Order p)
        {
            Order existingOrder = OrdersRepo.GetOrderById(Id);
            if (existingOrder == null)
            {
                return BadRequest(new { message = "No Order found" });
            }
            existingOrder.Name = p.Name;
            existingOrder.LocationId = p.LocationId;
            existingOrder.PrintingSpecifications = p.PrintingSpecifications;

            return Ok(new { message = "Order updated successfully" });

        }

    }
}
