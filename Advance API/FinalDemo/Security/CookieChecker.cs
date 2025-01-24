using Backend1.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results;
using System.Web.Http;
using System.Web.Services.Description;

namespace FinalDemo.Security
{
    public static class CookieChecker
    {
        public static IHttpActionResult IsAllowed(HttpRequestMessage request, int allowedRole)
        {
            try
            {
                var cookieHeader = request.Headers.GetCookies("VerificationToken").FirstOrDefault();
                if (cookieHeader == null || string.IsNullOrEmpty(cookieHeader["VerificationToken"]?.Value))
                {
                    Debug.WriteLine("VerificationToken cookie is missing or empty.");
                    return new ResponseMessageResult(new HttpResponseMessage(HttpStatusCode.Unauthorized));
                }

                string token = cookieHeader["VerificationToken"].Value;

                TokenDetails tokenDetails;
                try
                {
                    tokenDetails = JWTServiceProvider.ValidateTokenAndGetClaim(token);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Token validation failed: {ex.Message}");
                    return new ResponseMessageResult(new HttpResponseMessage(HttpStatusCode.Unauthorized));
                }

                if (!int.TryParse(tokenDetails.Role, out int userRole))
                {
                    Debug.WriteLine("Role in token is not a valid integer.");
                    return new ResponseMessageResult(new HttpResponseMessage(HttpStatusCode.Unauthorized));
                }

                if (userRole > allowedRole)
                {
                    Debug.WriteLine("User role exceeds allowed role.");
                    return new ResponseMessageResult(new HttpResponseMessage(HttpStatusCode.Unauthorized));
                }

                return null; // Access granted
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An unexpected error occurred: {ex.Message}");
                return new InternalServerErrorResult(request);
            }
        }
    }
}



/* 
#region old code
using Backend1.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalDemo.Security
{
    public static class CookieChecker
    {
        public static IHttpActionResult isAllowed(HttpRequestMessage request,int allowedRole)
        {
            try
            {
                var cookie = request.Headers.GetCookies("VerificationToken").FirstOrDefault();
                if (cookie == null || string.IsNullOrEmpty(cookie["VerificationToken"]?.Value))
                {
                    return Content(HttpStatusCode.Unauthorized, new { Message = "Access denied of this API" });
                }

                // Get the token from the cookie
                string token = cookie["VerificationToken"].Value;
                // Validate and extract token details
                TokenDetails tokenDetails = JWTServiceProvider.ValidateTokenAndGetClaim(token);

                // Compare the user's role with the allowed role
                int userRole = int.Parse(tokenDetails.Role);
                if (userRole > allowedRole)
                {
                    return Content(HttpStatusCode.Unauthorized, new { Message = "Access denied of this API due to lower role" });
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Content(HttpStatusCode.Unauthorized, new { Message = "Access denied of this API due to server error at verificaitoin time" });
            }
        }
    }
}
#endregion
 */