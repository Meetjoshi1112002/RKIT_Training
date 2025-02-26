using Backend1.Models;
using Backend1.Services;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Linq;

namespace Backend1.Controllers
{
    public class BFS_ALGOController : ApiController
    {
        [HttpPut]
        [EnableCors(origins: "https://localhost:44342/", headers:"*",methods:"PUT")]                           // --> applying cors to the controller
        [Route("api/printer-finding-algorithm")]
        public IHttpActionResult AssignPrinter(int order_id)
        {
            try
            {
                AuthenticateAndAuthorize();
                Console.WriteLine(order_id);
                PrintingDistributor p = AssignDistributor.Assign(order_id);

                if (p == null) throw new Exception("No Printer found for your order");

                return Ok(p);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                string path = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Basic API\\Flowx\\Logger\\logs.txt";
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Exception: {ex.Message}\n";

                System.IO.File.AppendAllText(path, logMessage);
                return Content(System.Net.HttpStatusCode.NotFound, new { message = ex.Message });
            }
        }

        private void AuthenticateAndAuthorize()
        {
            var cookies = Request.Headers.GetCookies("VerificationToken");
            if (cookies == null || !cookies.Any())
            {
                throw new UnauthorizedAccessException("Please log in to use this API.");
            }

            CookieHeaderValue cookie = cookies.FirstOrDefault();
            if (cookie != null)
            {
                string token = cookie["VerificationToken"]?.Value;
                if (string.IsNullOrEmpty(token))
                {
                    throw new UnauthorizedAccessException("Invalid token. Please log in again.");
                }

                TokenDetails user = JWTServiceProvider.ValidateTokenAndGetClaim(token);

                if (!int.TryParse(user.Role, out int role) || role != 1)
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
