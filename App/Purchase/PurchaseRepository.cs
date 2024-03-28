using MP_CS107L.App.Orders;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MP_CS107L.App.Orders;
using System.Web.UI.WebControls.WebParts;
using System.Diagnostics;
using System.Drawing;
using System.Web.Util;

namespace MP_CS107L.App.Purchase
{
    public class PurchaseRepository
    {

        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; 


        // get specific product from order
        public IEnumerable<Purchase.Order> GetProductFromOrder(string order)
        {
            List<Purchase.Order> ordersItems = new List<Purchase.Order>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"
                SELECT OrderItems.orderID, ProductInfo.prodID, quantity, size, price, username, orderStatus, orderTotal, prodName 
                FROM OrderItems
                LEFT JOIN OrderForm ON OrderItems.orderID = OrderForm.orderID
                LEFT JOIN ProductInfo ON ProductInfo.prodID = OrderItems.prodID
                WHERE OrderItems.orderID=@orderID;
                ";

                command.Parameters.Add("orderID", order);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Purchase.Order purchase = new Purchase.Order
                            {
                                OrderID = reader["orderID"].ToString(),
                                Username = reader["username"].ToString(),
                                OrderStatus = reader["orderStatus"].ToString(),
                            };

                            ordersItems.Add(purchase);
                        }
                    }
                }
            }
            return ordersItems;
        }


        // retrieve orderIDs
        public IEnumerable<OrderPlaced> GetAllPurchase()
        {
            List<OrderPlaced> purchases = new List<OrderPlaced>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                SELECT OrderForm.orderID, username, orderStatus, orderTotal, orderDate, orderTime
                FROM OrderForm;";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string orderID = reader["orderID"].ToString();
                            string status = reader["orderStatus"].ToString();

                            OrderPlaced orderPlaced = new OrderPlaced
                            {
                                OrderID = orderID,
                                Status = status,
                                OrderDate = reader.IsDBNull(reader.GetOrdinal("orderDate")) ? DateTime.MinValue : (DateTime)reader["orderDate"],
                                OrderTime = reader.IsDBNull(reader.GetOrdinal("orderTime")) ? TimeSpan.Zero : (TimeSpan)reader["orderTime"]
                            };

                            if (reader["username"] != DBNull.Value)
                                orderPlaced.Username = reader["username"].ToString();

                            purchases.Add(orderPlaced);
                        }
                    }
                }

                foreach (var orderPlaced in purchases)
                {
                    using (var orderedProductsCommand = connection.CreateCommand())
                    {
                        orderedProductsCommand.CommandText = @"
                    SELECT prodName, quantity
                    FROM OrderItems
                    LEFT JOIN ProductInfo ON OrderItems.prodID = ProductInfo.prodID
                    WHERE OrderItems.orderID = @OrderID;";
                        orderedProductsCommand.Parameters.AddWithValue("@OrderID", orderPlaced.OrderID);

                        using (var productReader = orderedProductsCommand.ExecuteReader())
                        {
                            while (productReader.Read())
                            {
                                OrderProduct product = new OrderProduct
                                {
                                    ProductName = productReader["prodName"].ToString(),
                                    Quantity = Convert.ToInt32(productReader["quantity"])
                                };
                                orderPlaced.Products.Add(product);
                            }
                        }
                    }
                }
            }
            return purchases;
        }


        // update order status
        public void UpdateOrderStatus(string orderID, string status)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"UPDATE OrderForm SET orderStatus = @newOrderStatus WHERE orderID = @orderID";
                command.Parameters.Add("newOrderStatus", status);
                command.Parameters.Add("orderID", orderID);

                command.ExecuteNonQuery();
            }
        } 



        // retrive all orders
        public IEnumerable<Purchase.Order> GetAllPurchases()
        {
            List<Purchase.Order> purchases = new List<Purchase.Order>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"
                SELECT OrderItems.orderID, ProductInfo.prodID, quantity, size, price, username, orderStatus, orderTotal, prodName 
                FROM OrderItems
                LEFT JOIN OrderForm ON OrderItems.orderID = OrderForm.orderID
                LEFT JOIN ProductInfo ON ProductInfo.prodID = OrderItems.prodID;
                ";

                using (var reader = command.ExecuteReader())
                {
                    
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Purchase.Order purchase = new Purchase.Order
                            {
                                OrderID = reader["orderID"].ToString(),
                                Username = reader["username"].ToString(),
                                OrderStatus = reader["orderStatus"].ToString(),
                                ProductName = reader["prodName"].ToString(),
                                ProductQty = (int)reader["quantity"],
                                ProductSize = reader["size"].ToString()
                            };

                            purchases.Add(purchase);
                        }
                    }
                    
                }
            }

            return purchases;
        }



        // retrieve current purchases of the specific user
        public IEnumerable<Orders.Cart> GetPurchases(string username)
        {
            List<Orders.Cart> purchases = new List<Orders.Cart>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    $"SELECT OrderItems.prodID, quantity, prodName, price, OrderItems.orderID, orderStatus, orderTotal, orderDate, orderTime " +
                    $"FROM OrderItems  " +
                    $"LEFT JOIN OrderForm ON OrderItems.orderID = OrderForm.orderID " +
                    $"LEFT JOIN ProductInfo ON OrderItems.prodID = ProductInfo.prodID " +
                    $"WHERE OrderItems.orderID LIKE 'C-{username}-%'";


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Orders.Cart purchase = new Orders.Cart
                        {
                            orderID = reader["orderID"].ToString(),
                            prodID = reader["prodID"].ToString(),
                            prodName = reader["prodName"].ToString(),
                            quantity = reader.IsDBNull(reader.GetOrdinal("quantity")) ? 0 : (int)reader["quantity"],
                            price = reader.IsDBNull(reader.GetOrdinal("price")) ? 0.0f : Convert.ToSingle(reader["price"]),
                            status = reader["orderStatus"].ToString(),
                            totalOrder = reader.IsDBNull(reader.GetOrdinal("orderTotal")) ? 0.0f : Convert.ToSingle(reader["orderTotal"]),
                            orderDate = reader.IsDBNull(reader.GetOrdinal("orderDate")) ? DateTime.MinValue : (DateTime)reader["orderDate"],
                            orderTime = reader.IsDBNull(reader.GetOrdinal("orderTime")) ? TimeSpan.Zero : (TimeSpan)reader["orderTime"]
                        };
                        purchases.Add(purchase);
                    }
                }
                return purchases;
            }
        }


        // insert order 
        public void InsertPurchase(string uOrderId, string username)
        {
            // purchase checkout
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText =
                            $"SELECT CartItems.prodID, CartItems.quantity, " +
                            $"CartItems.size, ProductInfo.prodName, ProductPrice.price " +
                            $"FROM CartItems " +
                            $"LEFT JOIN ProductInfo ON CartItems.prodID = ProductInfo.prodID " +
                            $"LEFT JOIN ProductPrice ON CartItems.prodID = ProductPrice.prodID " +
                            $"WHERE CartItems.CartID = @cartID";
                        command.Parameters.AddWithValue("@cartID", uOrderId);

                        // Read all data into a list
                        List<Orders.Cart> prodIDs = new List<Orders.Cart>();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Orders.Cart ordersCart = new Orders.Cart
                                {
                                    orderID = uOrderId,
                                    prodID = reader["prodID"].ToString(),
                                    quantity = Convert.ToInt32(reader["quantity"]),
                                    size = reader["size"].ToString(),
                                    price = Convert.ToSingle(reader["price"]),
                                };

                                prodIDs.Add(ordersCart);
                            }
                        }


                        // Insert order items using the list of product IDs
                        foreach (Orders.Cart cartProdID in prodIDs)
                        {
                            using (var commandInsert = connection.CreateCommand())
                            {
                                commandInsert.CommandText = "INSERT INTO OrderItems(orderID, prodID, quantity, size, price) VALUES (@orderID, @prodID, @quantity, @size, @price)";
                                commandInsert.Parameters.AddWithValue("@orderID", uOrderId);
                                commandInsert.Parameters.AddWithValue("@prodID", cartProdID.prodID);
                                commandInsert.Parameters.AddWithValue("@quantity", cartProdID.quantity);
                                commandInsert.Parameters.AddWithValue("@size", cartProdID.size);
                                commandInsert.Parameters.AddWithValue("@price", cartProdID.price);
                                commandInsert.ExecuteNonQuery();

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }


            // add to user to total order

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandText =
                        $"UPDATE InfoUsers SET totalOrder = totalOrder + 1 WHERE username = @username";
                    command.Parameters.AddWithValue("@username", username);

                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }


        // delete from cart
        public void DeleteCartPurchase(string orderId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText =
                        $"SELECT CartItems.prodID, CartItems.quantity, " +
                        $"CartItems.size, ProductInfo.prodName, ProductPrice.price " +
                        $"FROM CartItems " +
                        $"LEFT JOIN ProductInfo ON CartItems.prodID = ProductInfo.prodID " +
                        $"LEFT JOIN ProductPrice ON CartItems.prodID = ProductPrice.prodID " +
                        $"WHERE CartItems.CartID = @cartID";
                    command.Parameters.AddWithValue("@cartID", orderId);

                    // Execute the select statement to get the records to delete
                    List<string> prodIDsToDelete = new List<string>();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming prodID is the primary key to identify the records to delete
                            string prodID = reader["prodID"].ToString();
                            prodIDsToDelete.Add(prodID);
                        }
                    }

                    // delete the records using the retrieved prodIDs
                    foreach (string prodIDToDelete in prodIDsToDelete)
                    {
                        using (var deleteCommand = connection.CreateCommand())
                        {
                            deleteCommand.CommandText = "DELETE FROM CartItems WHERE prodID = @prodID";
                            deleteCommand.Parameters.AddWithValue("@prodID", prodIDToDelete);
                            deleteCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

    }
}