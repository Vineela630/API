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
        public HttpResponseMessage Registration(RegistrationDetails RegDetail)
        {
            try
            {
                UserRegistrationController userreg = new UserRegistrationController();
                string Response = userreg.Register(RegDetail);
                return Request.CreateResponse(HttpStatusCode.OK, Response);

            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Api/UserLogin")]
        public HttpResponseMessage UserLogin(UserLoginDetails loginDetails)
        {
            try
            {
                UserRegistrationController userlogin = new UserRegistrationController();
                string Response = userlogin.Login(loginDetails);
                return Request.CreateResponse(HttpStatusCode.OK, Response);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
