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
        /// <summary>
        /// Retrieves all orders based on optional query parameters.
        /// </summary>
        /// <param name="Name">Order name filter (optional).</param>
        /// <param name="Id">Order ID filter (optional).</param>
        /// <param name="PrintingSpecifications">Printing specifications filter (optional).</param>
        /// <param name="LocationId">Location ID filter (optional).</param>
        /// <returns>List of filtered orders or NotFound if no orders match.</returns>
        [HttpGet]
        [Route("api/get-all-orders")]
        [CacheFilter(TimeDuration = 500)]
        public IHttpActionResult GetAllOrders(string Name = null, int? Id = null, string PrintingSpecifications = null, int? LocationId = null)
        {
            try
            {
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
                LogException(ex);
                return Content(System.Net.HttpStatusCode.NotFound, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves a specific order by its ID.
        /// </summary>
        /// <param name="Id">The unique identifier of the order.</param>
        /// <returns>The requested order or NotFound if not found.</returns>
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

        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <param name="order">The order object to create.</param>
        /// <returns>The created order.</returns>
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

        /// <summary>
        /// Deletes an order by its ID.
        /// </summary>
        /// <param name="Id">The unique identifier of the order to delete.</param>
        /// <returns>A success message or error if deletion fails.</returns>
        [HttpDelete]
        [Route("api/orders/{Id}")]
        public IHttpActionResult DeleteOrder(int Id)
        {
            try
            {
                AuthenticateAndAuthorize();
                OrdersRepo.RemoveOrder(Id);
                return Ok(new { message = "Order deleted successfully." });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return Content(System.Net.HttpStatusCode.NotFound, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Updates an existing order.
        /// </summary>
        /// <param name="Id">The unique identifier of the order to update.</param>
        /// <param name="updatedOrder">The updated order object.</param>
        /// <returns>A success message or error if update fails.</returns>
        [HttpPut]
        [Route("api/orders/{Id}")]
        public HttpResponseMessage UpdateOrder(int Id, [FromBody] Order updatedOrder)
        {
            try
            {
                if (updatedOrder == null)
                {
                    throw new Exception("Order data cannot be null");
                }

                Order existingOrder = OrdersRepo.GetOrderById(Id);
                existingOrder.Name = updatedOrder.Name;
                existingOrder.LocationId = updatedOrder.LocationId;
                existingOrder.PrintingSpecifications = updatedOrder.PrintingSpecifications;

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, new { message = "Order updated successfully." });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Logs exceptions to a file.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        private void LogException(Exception ex)
        {
            string path = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Basic API\\Backend1\\Logger\\logs.txt";
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Exception: {ex.Message}\n";
            System.IO.File.AppendAllText(path, logMessage);
        }

        /// <summary>
        /// Authenticates and authorizes the user based on JWT.
        /// </summary>
        private void AuthenticateAndAuthorize()
        {
            CookieHeaderValue cookie = Request.Headers.GetCookies("VerificationToken").FirstOrDefault();
            if (cookie != null)
            {
                string token = cookie["VerificationToken"].Value;
                TokenDetails user = JWTServiceProvider.ValidateTokenAndGetClaim(token);
                if (int.Parse(user.Role) != 1)
                {
                    throw new UnauthorizedAccessException("You do not have the power to perform this action.");
                }
            }
            else
            {
                throw new UnauthorizedAccessException("Please log in to use this API.");
            }
        }
    }
}
