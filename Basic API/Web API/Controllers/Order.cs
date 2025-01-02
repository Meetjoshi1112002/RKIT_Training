using Microsoft.AspNetCore.Mvc;
using Web_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // GET: api/order
        [HttpGet]
        public ActionResult<List<Order>> GetOrders()
        {
            //return Ok(OrderPrinterData.currentOrders);
            return StatusCode(200, new
            {
                message = "Done",
                orders = OrderPrinterData.currentOrders
            });
        }

        // GET: api/order/{id}
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = OrderPrinterData.currentOrders.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }
            return Ok(order);
        }

        // POST: api/order
        [HttpPost]
        public ActionResult<Order> CreateOrder([FromBody] Order newOrder)
        {
            OrderPrinterData.currentOrders.Add(newOrder);
            return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.OrderId }, newOrder);
        }

        // PUT: api/order/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, [FromBody] Order updatedOrder)
        {
            var existingOrder = OrderPrinterData.currentOrders.FirstOrDefault(o => o.OrderId == id);
            if (existingOrder == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            existingOrder.Name = updatedOrder.Name;
            existingOrder.Spec = updatedOrder.Spec;
            return NoContent();
        }

        // DELETE: api/order/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var order = OrderPrinterData.currentOrders.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            OrderPrinterData.currentOrders.Remove(order);
            return NoContent();
        }
    }
}
