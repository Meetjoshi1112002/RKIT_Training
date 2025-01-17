using Backend1.Models;
using Backend1.Repository;
using Backend1.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Backend1.Controllers
{
    [RoutePrefix("api/user")] //This applies to all the actioun method in this controller
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("login")]
        [EnableCors(origins: "https://localhost:4200,https://localhost:3200", headers: "*", methods: "*")]                  // Applying cors to action method
        public HttpResponseMessage UserLogin(User user)
        {
            try
            {
                // Verify user credentials
                if (UserRepository.VerifyUser(user))
                {
                    // Generate JWT token
                    string token = JWTServiceProvider.GenerateToken(user.Name, user.Role.ToString());

                    // Prepare success response
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent($"Login successful for user: {user.Name}")
                    };

                    // Add JWT token as an HttpOnly cookie
                    CookieHeaderValue cookie = new CookieHeaderValue("VerificationToken", token)
                    {
                        HttpOnly = true,
                        Secure = Request.RequestUri.Scheme == Uri.UriSchemeHttps,
                        Expires = DateTimeOffset.UtcNow.AddHours(1),
                        Path = "/",  // Tells in which all request the cookeis must be visible
                    };
                    response.Headers.AddCookies(new[] { cookie });

                    return response;
                }

                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid user credentials.");
            }
            catch (Exception ex)
            {
                // Log exception details
                LogException(ex);

                // Return error response
                return Request.CreateResponse(HttpStatusCode.InternalServerError, 
                    new {
                    message = "An error occurred while processing your request.",
                    details = ex.Message
                });
            }
        }

        private void LogException(Exception ex)
        {
            string logFilePath = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Basic API\\Backend1\\Logger\\logs.txt";
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Exception: {ex.Message}\n";
            System.IO.File.AppendAllText(logFilePath, logMessage);
        }
    }
}
