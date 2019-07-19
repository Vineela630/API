using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.Models
{
    public class UserDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailID { get; set; }
    }
}