using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_CS107L.App.Staffs
{
    public class Staff
    {
        public string Username { get; set; }
        public string UserPass { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int TotalOrders { get; set; }
        public string TypeUser { get; set; }
    }
}