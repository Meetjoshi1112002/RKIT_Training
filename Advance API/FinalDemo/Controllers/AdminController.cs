using Backend1.Services;
using FinalDemo.BL;
using FinalDemo.Models;
using FinalDemo.Models.DTO.Admin_DTOs;
using FinalDemo.Models.Enum;
using FinalDemo.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;
using System.Web.Http;

namespace FinalDemo.Controllers
{
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        private readonly ServiceProvicer bl;

        public AdminController()
        {
            bl = new ServiceProvicer();
        }

        #region Admin Login for token generation in cookie
        [HttpPost]
        [Route("log-in")]
        public HttpResponseMessage LogIn(DTOADM01 adm)
        {
            try
            {
                Debug.WriteLine("hi " + JsonConvert.SerializeObject(adm));
                // Set entity type to Admin for the business logic layer
                bl.Etype = EnityType.Admin;

                // Fetch admin from the database using ID
                Response rs = bl.GetEntityById(adm.M01F01);

                // Check if the entity exists
                if (rs.IsError)
                {
                    // Return NotFound response with error message if admin is not found
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = rs.Message });
                }

                // Successfully found admin, now compare the encrypted password
                DTOADM01 _dbAdmin = rs.Data;
                if (Rjindial_Crypto_Service.Encrypt(adm.M01F03) == _dbAdmin.M01F03)
                {
                    // Password matches, successful login
                    string token = JWTServiceProvider.GenerateToken(_dbAdmin.M01F02, _dbAdmin.M01F04.ToString());

                    // Add JWT token as an HttpOnly cookie
                    var cookie = new CookieHeaderValue("VerificationToken", token)
                    {
                        HttpOnly = true,
                        Secure = Request.RequestUri.Scheme == Uri.UriSchemeHttps,
                        Expires = DateTimeOffset.UtcNow.AddHours(1),
                        Path = "/"  // Cookie will be sent in requests to any path
                    };

                    // Prepare success response with the JWT token
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent($"Login successful for user: {_dbAdmin.M01F02}") // Use username from DTO
                    };
                    response.Headers.AddCookies(new[] { cookie });

                    return response;
                }
                else
                {
                    // Password mismatch
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Message = "Invalid credentials" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
        #endregion

        #region Add a admin
        [HttpPost]
        [Route("add-admin")]
        public IHttpActionResult CreateAdmin(DTOADM01 obj)
        {
            IHttpActionResult isAllowed = CookieChecker.IsAllowed(Request, 1);

            if (isAllowed != null)
            {
                return isAllowed;  // Return the result directly
            }

            bl.Etype = EnityType.Admin;
            bl.Type = OpTpye.Add;
            Response rs = bl.AddEntity<DTOADM01>(obj);
            if (rs.IsError)
            {
                Debug.WriteLine(rs.Message);
                return Content(HttpStatusCode.InternalServerError, new { message = rs.Message });
            }
            else
            {
                return Ok();
            }
        }
        #endregion

        #region Add order
        [HttpPost]
        [Route("create-order")]
        public IHttpActionResult CreateOrder(DTOODR01 odr)
        {
            Debug.WriteLine("hi "+JsonConvert.SerializeObject(odr));

            if (odr == null)
            {
                return Content(HttpStatusCode.BadRequest, new { message = "Order data is missing." });
            }
            IHttpActionResult isAllowed = CookieChecker.IsAllowed(Request, 3);

            if (isAllowed != null)
            {
                return isAllowed;  // Return the result directly
            }
            bl.Etype = EnityType.Order;
            bl.Type = OpTpye.Add;
            Response rs = bl.AddEntity<DTOODR01>(odr);
            if (rs.IsError)
            {
                Debug.WriteLine(rs.Message);
                return Content(HttpStatusCode.InternalServerError, new { message = rs.Message });
            }
            else
            {
                return Ok();
            }
            
        }
        #endregion

        #region Add printer
        [HttpPost]
        [Route("create-printer")]
        public IHttpActionResult CreatePrinter(DTOPD01 pd)
        {
            Debug.WriteLine("hi " + JsonConvert.SerializeObject(pd));

            if (pd == null)
            {
                return Content(HttpStatusCode.BadRequest, new { message = "Order data is missing." });
            }
            IHttpActionResult isAllowed = CookieChecker.IsAllowed(Request, 2);

            if (isAllowed != null)
            {
                return isAllowed;  // Return the result directly
            }
            bl.Etype = EnityType.PD;
            bl.Type = OpTpye.Add;
            Response rs = bl.AddEntity<DTOPD01>(pd);
            if (rs.IsError)
            {
                Debug.WriteLine(rs.Message);
                return Content(HttpStatusCode.InternalServerError, new { message = rs.Message });
            }
            else
            {
                return Ok();
            }

        }
        #endregion

        #region Get all detials of admins (Meet -> created which all orders + created which all admins) --> store in file and return link  :> use linq here
        [HttpGet]
        [Route("get-admin-details")]
        public IHttpActionResult GetAdminDetails()
        {
            IHttpActionResult isAllowed = CookieChecker.IsAllowed(Request, 1);  //only super admin allowed to check details

            if (isAllowed != null)
            {
                return isAllowed;  // Return the result directly
            }
            Response res = bl.GetAdminDetails();

            if(res.IsError)
            {
                return Content(HttpStatusCode.InternalServerError,res.Message);
            }
            return Ok(res.Data);
        }
        #endregion

        #region Get for a printer (that which all orders he has got assigned byu whom)   :> Use ORM lite join operation here
        [HttpGet]
        [Route("get-order-details/{id}")]
        public IHttpActionResult GetOrderDetails([FromUri]int id)
        {
            Response res = bl.GetOrdersDetails(id);

            if (res.IsError)
            {
                return Content(HttpStatusCode.InternalServerError, res.Message);
            }
            return Ok(res.Data);
        }

        #endregion

        #region
        [HttpGet]
        [Route("get-super-view")]
        public IHttpActionResult SuperAdminView()
        {
            IHttpActionResult isAllowed = CookieChecker.IsAllowed(Request, 1);  //only super admin allowed to check details

            if (isAllowed != null)
            {
                return isAllowed;  // Return the result directly
            }
            Response res = bl.GetSuperAdminView();

            if (res.IsError)
            {
                return Content(HttpStatusCode.InternalServerError, res.Message);
            }
            return Ok(res.Data);
        }
        #endregion

    }
}
