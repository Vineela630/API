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
        public string Register(RegistrationDetails RegUser)
        {
            string Response = "Registered";
            try
            {
                using(LoginEntities ent = new LoginEntities())
                {
                    
                    var query = (from u in ent.UserDetails
                                 where u.UserID == RegUser.UserID
                                 select u.UserID).Count();
                    if (query > 0)
                    {
                        Response = "User name already exists";
                    }
                    else
                    {
                        UserDetail user = new UserDetail()
                        {
                            FirstName = RegUser.FirstName,
                            LastName = RegUser.LastName,
                            UserID = RegUser.UserID,
                            Password = RegUser.Password,
                            PhoneNumber = RegUser.PhoneNumber,
                            EmailID = RegUser.EmailID
                        };

                        ent.UserDetails.Add(user);
                        if (ent.SaveChanges() > 0)
                        {
                            Response = "Registered";
                        }
                        else
                        {
                            Response = "Failed to Register";
                        }
                    }
                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Response;
        }

        public string Login(UserLoginDetails loginDetails)
        {
            string Response = "Logged in successfully";
            try
            {
                using(LoginEntities ent = new LoginEntities())
                {
                    var CheckUser = (from user in ent.UserDetails
                                 where loginDetails.UserID == user.UserID
                                 select user.UserID
                                ).Count();
                    if (CheckUser == 0)
                    {
                        Response = "User Doesn't exist";
                    }
                    else
                    {
                        var VerifyPwd = (from user in ent.UserDetails
                                         where loginDetails.UserID == user.UserID 
                                         select user.Password
                                        ).FirstOrDefault().ToString();
                        if(VerifyPwd == loginDetails.Password)
                        {
                            Response = "Logged in successfully";
                        }
                        else
                        {
                            Response = "Password Doesn't match";
                        }
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
