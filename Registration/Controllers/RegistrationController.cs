using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Registration.DAL;
using Registration.Models;


namespace Registration.Controllers
{
    public class RegistrationController : ApiController
    {
        [HttpPost]
        [Route("Api/UserRegistration")]
        public HttpResponseMessage Registration(UserDetails userDetails)
        {
            try
            {
                UserRegistrationController userreg = new UserRegistrationController();
                string Response = userreg.Register(userDetails);
                return Request.CreateResponse(HttpStatusCode.OK, Response);

            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
