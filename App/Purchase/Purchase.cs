using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_CS107L.App.Orders
{
    public class Purchase
    {


        public string Username { get; set; }
        public string OrderStatus { get; set; }
        public string OrderID { get; set; } 


        public List<Cart> Carts { get; set; }


        public Purchase(string username, string orderID)
        {
            Username = username;
            OrderID = orderID;
            Carts = new List<Cart>();
        }


        public void AddOrder(string productID, int qty, float price, string orderID)
        {
            Carts.Add(new Cart 
            {
                prodID = productID,
                quantity = qty,
                price = price,
                orderID = orderID
            });
        }

        public Cart GetOrderByID(string orderId)
        {
            return Carts.FirstOrDefault(o => o.orderID == orderId);
        }
    }
}