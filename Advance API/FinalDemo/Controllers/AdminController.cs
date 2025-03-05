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
    /// <summary>
    /// Controller for managing admin-related operations such as authentication, user management, and order handling.
    /// </summary>
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        private readonly ServiceProvicer bl;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController"/> class.
        /// </summary>
        public AdminController()
        {
            bl = new ServiceProvicer();
        }

        #region Admin Login for token generation in cookie
        /// <summary>
        /// Logs in an admin user and generates a JWT token stored in an HttpOnly cookie.
        /// </summary>
        /// <param name="adm">Admin login details</param>
        /// <returns>HTTP response with authentication token or error message</returns>
        [HttpPost]
        [Route("log-in")]
        public HttpResponseMessage LogIn(DTOADM01 adm)
        {
            try
            {
                Debug.WriteLine("hi " + JsonConvert.SerializeObject(adm));
                bl.Etype = EnityType.Admin;

                // Fetch admin details
                Response rs = bl.GetEntityById(adm.M01F01);

                if (rs.IsError)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = rs.Message });
                }

                // Validate password
                DTOADM01 _dbAdmin = rs.Data;
                if (Rjindial_Crypto_Service.Encrypt(adm.M01F03) == _dbAdmin.M01F03)
                {
                    string token = JWTServiceProvider.GenerateToken(_dbAdmin.M01F02, _dbAdmin.M01F04.ToString());
                    var cookie = new CookieHeaderValue("VerificationToken", token)
                    {
                        HttpOnly = true,
                        Secure = Request.RequestUri.Scheme == Uri.UriSchemeHttps,
                        Expires = DateTimeOffset.UtcNow.AddHours(1),
                        Path = "/"
                    };
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent($"Login successful for user: {_dbAdmin.M01F02}")
                    };
                    response.Headers.AddCookies(new[] { cookie });
                    return response;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Message = "Invalid credentials" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
        #endregion

        #region Create Admin
        /// <summary>
        /// Adds a new admin user.
        /// </summary>
        /// <param name="obj">Admin details</param>
        /// <returns>HTTP status indicating success or failure</returns>
        [HttpPost]
        [Route("add-admin")]
        public IHttpActionResult CreateAdmin(DTOADM01 obj)
        {
            IHttpActionResult isAllowed = CookieChecker.IsAllowed(Request, 1);
            if (isAllowed != null)
            {
                return isAllowed;
            }

            bl.Etype = EnityType.Admin;
            bl.Type = OpTpye.Add;
            Response rs = bl.AddEntity<DTOADM01>(obj);

            if (rs.IsError)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = rs.Message });
            }
            else
            {
                return Ok();
            }
        }
        #endregion

        #region Create Order
        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <param name="odr">Order details</param>
        /// <returns>HTTP status indicating success or failure</returns>
        [HttpPost]
        [Route("create-order")]
        public IHttpActionResult CreateOrder(DTOODR01 odr)
        {
            Debug.WriteLine("hi " + JsonConvert.SerializeObject(odr));
            if (odr == null)
            {
                return Content(HttpStatusCode.BadRequest, new { message = "Order data is missing." });
            }

            IHttpActionResult isAllowed = CookieChecker.IsAllowed(Request, 3);
            if (isAllowed != null)
            {
                return isAllowed;
            }

            bl.Etype = EnityType.Order;
            bl.Type = OpTpye.Add;
            Response rs = bl.AddEntity<DTOODR01>(odr);

            if (rs.IsError)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = rs.Message });
            }
            else
            {
                return Ok();
            }
        }
        #endregion

        #region Create Printer
        /// <summary>
        /// Registers a new printer.
        /// </summary>
        /// <param name="pd">Printer details</param>
        /// <returns>HTTP status indicating success or failure</returns>
        [HttpPost]
        [Route("create-printer")]
        public IHttpActionResult CreatePrinter(DTOPD01 pd)
        {
            Debug.WriteLine("hi " + JsonConvert.SerializeObject(pd));
            if (pd == null)
            {
                return Content(HttpStatusCode.BadRequest, new { message = "Printer data is missing." });
            }

            IHttpActionResult isAllowed = CookieChecker.IsAllowed(Request, 2);
            if (isAllowed != null)
            {
                return isAllowed;
            }

            bl.Etype = EnityType.PD;
            bl.Type = OpTpye.Add;
            Response rs = bl.AddEntity<DTOPD01>(pd);

            if (rs.IsError)
            {
                return Content(HttpStatusCode.InternalServerError, new { message = rs.Message });
            }
            else
            {
                return Ok();
            }
        }
        #endregion

        #region Get Admin Details
        /// <summary>
        /// Retrieves details of all admins and their created orders/admins.
        /// </summary>
        /// <returns>Admin details or error message</returns>
        [HttpGet]
        [Route("get-admin-details")]
        public IHttpActionResult GetAdminDetails()
        {
            IHttpActionResult isAllowed = CookieChecker.IsAllowed(Request, 1);
            if (isAllowed != null)
            {
                return isAllowed;
            }

            Response res = bl.GetAdminDetails();

            if (res.IsError)
            {
                return Content(HttpStatusCode.InternalServerError, res.Message);
            }
            else
            {
                return Ok(res.Data);
            }
        }
        #endregion

        #region Get Order Details
        /// <summary>
        /// Retrieves details of orders assigned to a printer.
        /// </summary>
        /// <param name="id">Printer ID</param>
        /// <returns>Order details</returns>
        [HttpGet]
        [Route("get-order-details/{id}")]
        public IHttpActionResult GetOrderDetails([FromUri] int id)
        {
            Response res = bl.GetOrdersDetails(id);

            if (res.IsError)
            {
                return Content(HttpStatusCode.InternalServerError, res.Message);
            }
            else
            {
                return Ok(res.Data);
            }
        }
        #endregion

        #region Super Admin View
        /// <summary>
        /// Retrieves a view for the super admin.
        /// </summary>
        /// <returns>Super admin data</returns>
        [HttpGet]
        [Route("get-super-view")]
        public IHttpActionResult SuperAdminView()
        {
            IHttpActionResult isAllowed = CookieChecker.IsAllowed(Request, 1);
            if (isAllowed != null)
            {
                return isAllowed;
            }

            Response res = bl.GetSuperAdminView();

            if (res.IsError)
            {
                return Content(HttpStatusCode.InternalServerError, res.Message);
            }
            else
            {
                return Ok(res.Data);
            }
        }
        #endregion
    }
}
