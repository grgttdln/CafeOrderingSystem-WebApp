using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace MP_CS107L.App.Orders
{
    public class CartRepository
    {

        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        public List<Cart> carts = new List<Cart>()
        {

        };


        // adding to cart in database
        public void AddItemToCart(Cart cart, string username)
        {
            carts.Add(cart);

            // add to database 
            InsertCart(carts, username);
        }


        // retrieving item in database to add to cart
        public IEnumerable<Cart> FindItem(Cart cart, int qty)
        {
            List<Cart> result = new List<Cart>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = $"SELECT * FROM ProductPrice WHERE prodID = @productID";
                command.Parameters.AddWithValue("@productID", cart.prodID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Cart()
                        {
                            prodID = reader["prodID"].ToString(),
                            quantity = qty,
                            price = Convert.ToSingle(reader["price"]) * qty,
                        });
                    }
                }
            }

            return result;
        }


        public void InsertCart(List<Cart> carts, string username)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (var cart in carts)
                {
                    // Check if the product is already in the cart
                    using (var checkCommand = connection.CreateCommand())
                    {
                        checkCommand.CommandText = "SELECT COUNT(*) FROM CartItems WHERE prodID = @prodID AND cartID LIKE 'C-' + @username + '%'";
                        checkCommand.Parameters.AddWithValue("@prodID", cart.prodID);
                        checkCommand.Parameters.AddWithValue("@username", username);


                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            // Product is already in the cart, update the quantity
                            using (var updateCommand = connection.CreateCommand())
                            {
                                updateCommand.CommandText = "UPDATE CartItems SET quantity = quantity + @quantity WHERE prodID = @prodID";
                                updateCommand.Parameters.AddWithValue("@prodID", cart.prodID);
                                updateCommand.Parameters.AddWithValue("@quantity", cart.quantity);

                                updateCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string cartID;

                            // Get the user's cart ID or create a new one if the user does not exist
                            using (var retrieveCommand = connection.CreateCommand())
                            {
                                retrieveCommand.CommandText = "SELECT totalOrder FROM InfoUsers WHERE username = @username";
                                retrieveCommand.Parameters.AddWithValue("@username", username);

                                var result = retrieveCommand.ExecuteScalar();
                                if (result != null && result != DBNull.Value)
                                {
                                    int currOrder = Convert.ToInt32(result);
                                    cartID = $"C-{username}-{currOrder}";
                                }
                                else
                                {
                                    // Create a new cart for the user
                                    using (var createCartCommand = connection.CreateCommand())
                                    {
                                        createCartCommand.CommandText = "INSERT INTO InfoUsers (username, totalOrder) VALUES (@username, 1)";
                                        createCartCommand.Parameters.AddWithValue("@username", username);
                                        createCartCommand.ExecuteNonQuery();
                                    }
                                    cartID = $"C-{username}-1";
                                }
                            }

                            // Product is not in the cart, insert a new item
                            using (var insertCommand = connection.CreateCommand())
                            {
                                insertCommand.CommandText = "INSERT INTO CartItems(prodID, quantity, size, cartID) VALUES (@prodID, @quantity, @size, @cartID)";
                                insertCommand.Parameters.AddWithValue("@prodID", cart.prodID);
                                insertCommand.Parameters.AddWithValue("@quantity", cart.quantity);
                                insertCommand.Parameters.AddWithValue("@size", "regular");
                                insertCommand.Parameters.AddWithValue("@cartID", cartID);

                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }


        public string GetCartIDUser(string username)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT totalOrder FROM InfoUsers WHERE username = @username";
                    command.Parameters.AddWithValue("@username", username);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        int currOrder = (int)result;
                        string cartID = $"C-{username}-{currOrder}";
                        return cartID;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }


        public (IEnumerable<Cart> items, float total) GetItemsFromCartWithTotal(string userCartID)
        {
            float totalItems = 0;
            List<Cart> carts = new List<Cart>();

            using (var connection = new SqlConnection(connectionString))
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
                command.Parameters.AddWithValue("@cartID", userCartID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        float price = Convert.ToSingle(reader["price"]);
                        int quantity = (int)reader["quantity"];
                        float itemTotal = price * quantity;
                        totalItems += itemTotal;

                        Cart cart = new Cart();
                        cart.prodID = reader["prodID"].ToString();
                        cart.prodName = reader["prodName"].ToString();
                        cart.quantity = quantity;
                        cart.size = reader["size"].ToString();
                        cart.price = itemTotal;

                        carts.Add(cart);
                    }
                }
            }

            return (carts, totalItems);
        }



        // delete a single item from the cart 
        public void DeleteItemFromCart(string prodId)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    $"DELETE FROM CartItems WHERE prodID = @productID";
                command.Parameters.AddWithValue("@productID", prodId);

                command.ExecuteNonQuery();
            }
        }


        // subtracting quantity 
        public void SubtractQuantity(string prodId, int qty)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {

                connection.Open();

                // Subtract the specified quantity from the existing quantity in the database
                command.CommandText = "UPDATE CartItems SET quantity = quantity - @quantity WHERE prodID = @productID";
                command.Parameters.AddWithValue("@quantity", 1);
                command.Parameters.AddWithValue("@productID", prodId);

                int rowsAffected = command.ExecuteNonQuery();

            }
        }


        // adding quantity
        public void AddQuantity(string prodId, int qty)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {

                connection.Open();

                // Subtract the specified quantity from the existing quantity in the database
                command.CommandText = "UPDATE CartItems SET quantity = quantity + @quantity WHERE prodID = @productID";
                command.Parameters.AddWithValue("@quantity", 1);
                command.Parameters.AddWithValue("@productID", prodId);

                int rowsAffected = command.ExecuteNonQuery();

            }
        }


        // submit order
        public void SubmitOrder(string username)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT MAX(CAST(RIGHT(orderID, LEN(orderID) - CHARINDEX('-', orderID, CHARINDEX('-', orderID) + 1)) AS INT)) FROM OrderForm WHERE username = @username";
                command.Parameters.AddWithValue("@username", username);

                var result = command.ExecuteScalar();
                int maxOrderId = result == DBNull.Value ? 0 : Convert.ToInt32(result);

                string orderID = "C-" + username + "-" + (maxOrderId + 1);
               
                using (var insertOrder = connection.CreateCommand())
                {
                    insertOrder.CommandText = "INSERT INTO OrderForm (OrderID, Username, OrderStatus, orderDate, orderTime) VALUES (@orderID, @username, 'pending', @orderDate, @orderTime)";
                    insertOrder.Parameters.AddWithValue("@orderID", orderID);
                    insertOrder.Parameters.AddWithValue("@username", username);
                    insertOrder.Parameters.AddWithValue("@orderDate", DateTime.Now.Date);
                    insertOrder.Parameters.AddWithValue("@orderTime", DateTime.Now.TimeOfDay);

                    insertOrder.ExecuteNonQuery();
                }
            }
        }



        public void CalculateTotal(string orderID)
        {
            float total = 0;

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandText = "SELECT price, quantity FROM OrderItems WHERE orderID = @ID";
                    command.Parameters.AddWithValue("@ID", orderID);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
                            {
                                if (float.TryParse(reader["price"].ToString(), out float price) && int.TryParse(reader["quantity"].ToString(), out int qty))
                                {
                                    total += price * qty;
                                }
                                else
                                {
                                    // Log or handle invalid data
                                    Console.WriteLine("Invalid data found while parsing.");
                                }
                            }
                            else
                            {
                                // Handle null values 
                                throw new Exception("Null value encountered in the data reader.");
                            }
                        }
                    }

                    // Update orderTotal in OrderForm table
                    using (var updateTotal = connection.CreateCommand())
                    {
                        updateTotal.CommandText = "UPDATE OrderForm SET orderTotal = @total WHERE orderID = @orderID";
                        updateTotal.Parameters.AddWithValue("@total", total);
                        updateTotal.Parameters.AddWithValue("@orderID", orderID);
                        updateTotal.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL-related exceptions
                Console.WriteLine("An SQL error occurred: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

    }
}