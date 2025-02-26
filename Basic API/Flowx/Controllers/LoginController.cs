using Backend1.Models;
using Backend1.Repository;
using Backend1.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Backend1.Controllers
{
    /// <summary>
    /// Controller responsible for user authentication and login operations.
    /// </summary>
    [RoutePrefix("api/user")] // This applies to all the action methods in this controller
    public class LoginController : ApiController
    {
        /// <summary>
        /// Authenticates a user and returns a JWT token in an HTTP-only cookie.
        /// </summary>
        /// <param name="user">User credentials for authentication.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpPost]
        [Route("login")]
        [EnableCors(origins: "https://localhost:4200,https://localhost:3200", headers: "*", methods: "POST")] // Applying CORS to action method
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
                        Path = "/",  // Tells in which all requests the cookies must be visible
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
                    new
                    {
                        message = "An error occurred while processing your request.",
                        details = ex.Message
                    });
            }
        }

        /// <summary>
        /// Logs exception details into a file for debugging purposes.
        /// </summary>
        /// <param name="ex">Exception to be logged.</param>
        private void LogException(Exception ex)
        {
            string logFilePath = "C:\\Users\\meet.j\\Desktop\\RKIT_Training\\Basic API\\Flowx\\Logger\\logs.txt";
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Exception: {ex.Message}\n";
            System.IO.File.AppendAllText(logFilePath, logMessage);
        }
    }
}
