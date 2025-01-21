using Backend1.Models;
using Backend1.Repository;
using Backend1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Backend1.Caching;
namespace Backend1.Controllers
{
    public class OrderController : ApiController
    {
        // GET: api/get-all-orders
        [HttpGet]
        [Route("api/get-all-orders")] // Ensure this matches the WebApiConfig
        [CacheFilter(TimeDuration =500)]
        public IHttpActionResult GetAllOrders(string Name = null, int? Id = null, string PrintingSpecifications = null, int? LocationId = null)
        {
            try
            {
                // Filter OrdersRepo based on query parameters with AND logic
                List<Order> suitableOrder = OrdersRepo.GetAllOrder()
                    .Where(v =>
                        (!Id.HasValue || v.Id == Id) &&
                        (string.IsNullOrEmpty(Name) || v.Name == Name) &&
                        (string.IsNullOrEmpty(PrintingSpecifications) || v.PrintingSpecifications == PrintingSpecifications) &&
                        (!LocationId.HasValue || v.LocationId == LocationId))
                    .ToList();

                if (!suitableOrder.Any())
                {
                    return NotFound();
                }

                return Ok(suitableOrder);
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

        // GET: api/orders/{Id}
        [HttpGet]
        [Route("api/orders/{Id}")]
        public IHttpActionResult GetOrderById(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("Invalid ID. Please provide a valid one.");
            }

            Order order = OrdersRepo.GetOrderById(Id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // POST: api/create-order
        [HttpPost]
        [Route("api/create-order")]
        public IHttpActionResult CreateOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order cannot be null.");
            }

            OrdersRepo.AddOrder(order);

            return Created($"api/orders/{order.Id}", order);
        }

        // DELETE: api/orders/{Id}
        [HttpDelete]
        [Route("api/orders/{Id}")]
        public IHttpActionResult DeleteOrder(int Id)
        {
            try
            {
                // Authentication step
                CookieHeaderValue cookie = Request.Headers.GetCookies("VerificationToken").FirstOrDefault();
                if(cookie != null)
                {
                    string token = cookie["VerificationToken"].Value;
                    TokenDetails user = JWTServiceProvider.ValidateTokenAndGetClaim(token);
                    Console.WriteLine(user.Role);
                    // Autorization Step
                    if (int.Parse(user.Role) !=1 )
                    {
                        return Content(System.Net.HttpStatusCode.Unauthorized, new { message = "You dont have the power to do this"});
                    }

                }
                else
                {
                    return Content(System.Net.HttpStatusCode.Unauthorized, new { message = "Please log in to use this API" });
                }
                OrdersRepo.RemoveOrder(Id);

                return Ok(new { message = "Order deleted successfully." });
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

        // PUT: api/orders/{Id}
        [HttpPut]
        [Route("api/orders/{Id}")]
        public HttpResponseMessage UpdateOrder(int Id, [FromBody] Order updatedOrder)
        {
            try
            {
            if (updatedOrder == null)
            {
                //return BadRequest("Order data cannot be null.");
                throw new Exception("Order data connot be null");
            }

            Order existingOrder = OrdersRepo.GetOrderById(Id);

            existingOrder.Name = updatedOrder.Name;
            existingOrder.LocationId = updatedOrder.LocationId;
            existingOrder.PrintingSpecifications = updatedOrder.PrintingSpecifications;

                //return Ok(new { message = "Order updated successfully." });
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, new { message = "done" });

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                string path = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Basic API\\Backend1\\Logger\\logs.txt";
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Exception: {ex.Message}\n";

                System.IO.File.AppendAllText(path, logMessage);
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, new { message = ex.Message });

            }
        }
    }
}
