using Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Registration.DAL
{
    public class UserRegistrationController : ApiController
    {
        public string Register(UserDetails userDetails)
        {
            string Response = "Inserted";
            try
            {
                using(APIEntities ent = new APIEntities())
                {
                    User user = new User()
                    {
                        FirstName = userDetails.FirstName,
                        LastName = userDetails.LastName,
                        UserID = userDetails.UserID,
                        Password = userDetails.Password,
                        PhoneNumber = userDetails.PhoneNumber,
                        EmailID = userDetails.EmailID
                    };
                    ent.Users.Add(user);
                    if(ent.SaveChanges() > 0)
                    {
                        Response = "Inserted";
                    }
                    else
                    {
                        Response = "Not Inserted";
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Response;
        }

    }
}
