using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_CS107L.App.Purchase
{
    public class Order
    {
        public string OrderID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductQty { get; set; }
        public string ProductSize { get; set; }
        public float ProductPrice { get; set; }
        public string Username { get; set; }
        public string OrderStatus { get; set; }
        public float OrderTotal { get; set; }
    }
}