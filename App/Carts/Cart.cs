using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_CS107L.App.Orders
{
    // Cart Item Structure
    public class Cart
    {
        public string prodID { get; set; }
        public string prodName { get; set; }
        public int quantity { get; set; }   
        public float price { get; set; }
        public string size { get; set; }
        public string orderID { get; set; }
        public string orderDateTime { get; set; }   
        public string status { get; set; }
        public float totalOrder { get; set; }

        public DateTime orderDate { get; set; } 
        public TimeSpan orderTime { get; set; }

    }
}