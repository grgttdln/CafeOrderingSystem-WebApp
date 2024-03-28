using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MP_CS107L.App.Product
{
    public class ProductRepository
    {

        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        // get all specific products
        public IEnumerable<Product> GetAllSpecificProducts(string productType)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();


                if (!string.IsNullOrEmpty(productType))
                {
                    command.CommandText = @"
                    SELECT ProductInfo.prodID, ProductInfo.prodName, ProductInfo.prodDesc, ProductInfo.prodType, 
                    ProductPrice.price, ProductPrice.size, ProductPrice.prodAvail 
                    FROM ProductInfo 
                    JOIN ProductPrice ON ProductInfo.prodID = ProductPrice.prodID
                    WHERE prodType = @prodType;";

                    command.Parameters.Add("prodType", productType);
                } 
                else
                {
                    command.CommandText = @"
                        SELECT ProductInfo.prodID, ProductInfo.prodName, ProductInfo.prodDesc, ProductInfo.prodType, 
                        ProductPrice.price, ProductPrice.size, ProductPrice.prodAvail 
                        FROM ProductInfo 
                        JOIN ProductPrice ON ProductInfo.prodID = ProductPrice.prodID;
                    ";
                }

                using (var reader = command.ExecuteReader())
                {
                    var products = new List<Product>();

                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = reader.GetString(reader.GetOrdinal("prodID")),
                            Name = reader.GetString(reader.GetOrdinal("prodName")),
                            Description = reader.GetString(reader.GetOrdinal("prodDesc")),
                            Type = reader.GetString(reader.GetOrdinal("prodType")),
                            Price = reader.GetDouble(reader.GetOrdinal("price")),
                            Size = reader.GetString(reader.GetOrdinal("size")),
                            IsAvailable = reader.GetBoolean(reader.GetOrdinal("prodAvail"))
                        });
                    }
                    return products;
                }
            }
        }


        // get all products 
        public IEnumerable<Product> GetAllProducts()
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"
                        SELECT ProductInfo.prodID, ProductInfo.prodName, ProductInfo.prodDesc, ProductInfo.prodType, 
                        ProductPrice.price, ProductPrice.size, ProductPrice.prodAvail 
                        FROM ProductInfo 
                        JOIN ProductPrice ON ProductInfo.prodID = ProductPrice.prodID;
                    ";

                using (var reader = command.ExecuteReader())
                {
                    var products = new List<Product>();

                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = reader.GetString(reader.GetOrdinal("prodID")),
                            Name = reader.GetString(reader.GetOrdinal("prodName")),
                            Description = reader.GetString(reader.GetOrdinal("prodDesc")),
                            Type = reader.GetString(reader.GetOrdinal("prodType")),
                            Price = reader.GetDouble(reader.GetOrdinal("price")),
                            Size = reader.GetString(reader.GetOrdinal("size")),
                            IsAvailable = reader.GetBoolean(reader.GetOrdinal("prodAvail"))
                        });
                    }

                    return products;
                }
            }
        }


        // update availability of products
        public void UpdateAvailProducts(string id, string availability)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                string isAvail = "1";
                if (availability == "True")
                {
                    isAvail = "1";
                }
                else
                {
                    isAvail = "0";
                }

                command.CommandText = @"
                        UPDATE ProductPrice SET prodAvail = @availability WHERE prodID = @productID;
                    ";
                command.Parameters.AddWithValue("@productID", id);
                command.Parameters.AddWithValue("@availability", isAvail);

                command.ExecuteNonQuery();
            }
        }

    }
}