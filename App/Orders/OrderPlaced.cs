using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_CS107L.App.Orders
{
    public class OrderPlaced
    {
        public string OrderID { get; set; }
        public List<OrderProduct> Products { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeSpan OrderTime { get; set; }
        public string Status { get; set; }
        public string Username { get; set; }

        public OrderPlaced()
        {
            Products = new List<OrderProduct>();
        }
    }

    public class OrderProduct
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}