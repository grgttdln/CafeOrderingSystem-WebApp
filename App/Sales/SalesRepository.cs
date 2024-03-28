using MP_CS107L.App.Sale;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MP_CS107L.App.Sales
{
    public class SalesRepository
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // get most product sold
        public IEnumerable<Sale.Sale> GetMostSold()
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"SELECT TOP 1
                    ProductInfo.prodID,
                    ProductInfo.prodName,
                    ProductPrice.price,
                    SUM(OrderItems.quantity) AS total_quantity
                FROM
                    OrderForm
                LEFT JOIN
                    OrderItems ON OrderItems.orderID = OrderForm.orderID
                LEFT JOIN
                    ProductInfo ON ProductInfo.prodID = OrderItems.prodID
                LEFT JOIN
                    ProductPrice ON ProductPrice.prodID = ProductInfo.prodID 
                WHERE
                    OrderForm.orderStatus = 'done'
                GROUP BY
                    ProductInfo.prodID,
                    ProductInfo.prodName,
                    ProductPrice.price 
                ORDER BY
                    total_quantity DESC;";

                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new Sale.Sale()
                    {
                        ProductItem = row["prodName"].ToString(),
                        MaxQuantity = (int)row["total_quantity"],
                        ProductID = row["prodID"].ToString(),
                        Price = Convert.ToSingle(row["price"])
                    })
                .ToList();

            }
        }



        // get most least sold
        public IEnumerable<Sale.Sale> GetLeastSold()
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"SELECT TOP 1
                    ProductInfo.prodID,
                    ProductInfo.prodName,
                    ProductPrice.price,
                    SUM(OrderItems.quantity) AS total_quantity
                FROM
                    OrderForm
                LEFT JOIN
                    OrderItems ON OrderItems.orderID = OrderForm.orderID
                LEFT JOIN
                    ProductInfo ON ProductInfo.prodID = OrderItems.prodID
                LEFT JOIN
                    ProductPrice ON ProductPrice.prodID = ProductInfo.prodID 
                WHERE
                    OrderForm.orderStatus = 'done'
                GROUP BY
                    ProductInfo.prodID,
                    ProductInfo.prodName,
                    ProductPrice.price 
                ORDER BY
                    total_quantity ASC;";

                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new Sale.Sale()
                    {
                        ProductItem = row["prodName"].ToString(),
                        MaxQuantity = (int)row["total_quantity"],
                        ProductID = row["prodID"].ToString(),
                        Price = Convert.ToSingle(row["price"])
                    })
                .ToList();
            }
        }



        // view all product sales
        public IEnumerable<Sale.Sale> GetAllSoldProduct()
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"
                    SELECT
                        ProductInfo.prodID,
                        ProductInfo.prodName,
                        ProductPrice.price,
                        orderStatus,
                        COALESCE(SUM(OrderItems.quantity), 0) AS total_quantity
                    FROM
                        ProductInfo
                    LEFT JOIN
                        OrderItems ON ProductInfo.prodID = OrderItems.prodID
                    LEFT JOIN
                        OrderForm ON OrderItems.orderID = OrderForm.orderID
                    LEFT JOIN
                        ProductPrice ON ProductInfo.prodID = ProductPrice.prodID
                    WHERE
                        orderStatus='done'
                    GROUP BY
                        ProductInfo.prodID,
                        ProductInfo.prodName,
                        ProductPrice.price,
                        orderStatus
                    ORDER BY
                        total_quantity DESC;";


                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new Sale.Sale()
                    {
                        ProductItem = row["prodName"].ToString(),
                        MaxQuantity = (int)row["total_quantity"],
                        ProductID = row["prodID"].ToString(),
                        Price = Convert.ToSingle(row["price"])
                    })
                .ToList();
            }
        }



        // get products based today
        public IEnumerable<Sale.Sale> GetSpecificDateSoldProductToday()
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"
                SELECT
                    ProductInfo.prodID,
                    ProductInfo.prodName,
                    ProductPrice.price,
                    COALESCE(SUM(OrderItems.quantity), 0) AS total_quantity
                FROM
                    ProductInfo
                LEFT JOIN
                    OrderItems ON ProductInfo.prodID = OrderItems.prodID
                LEFT JOIN
                    OrderForm ON OrderItems.orderID = OrderForm.orderID
                LEFT JOIN
                    ProductPrice ON ProductInfo.prodID = ProductPrice.prodID
                WHERE
                    OrderForm.orderDate = CONVERT(date, GETDATE()) 
                    AND OrderForm.orderStatus = 'Done'
                GROUP BY
                    ProductInfo.prodID,
                    ProductInfo.prodName,
                    ProductPrice.price
                ORDER BY
                    total_quantity DESC;";

                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new Sale.Sale()
                    {
                        ProductItem = row["prodName"].ToString(),
                        MaxQuantity = (int)row["total_quantity"],
                        ProductID = row["prodID"].ToString(),
                        Price = Convert.ToSingle(row["price"])
                    })
                .ToList();
            }
        }


        // get specific product based this week
        public IEnumerable<Sale.Sale> GetSpecificDateSoldProductThisWeek()
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"
                SELECT
                    ProductInfo.prodID,
                ProductInfo.prodName,
                    ProductPrice.price,
                    COALESCE(SUM(OrderItems.quantity), 0) AS total_quantity
                FROM
                    ProductInfo
                LEFT JOIN
                    OrderItems ON ProductInfo.prodID = OrderItems.prodID
                LEFT JOIN
                    OrderForm ON OrderItems.orderID = OrderForm.orderID
                LEFT JOIN
                    ProductPrice ON ProductInfo.prodID = ProductPrice.prodID
                WHERE
                    DATEPART(WEEK, OrderForm.orderDate) = DATEPART(WEEK, GETDATE())
                    AND DATEPART(YEAR, OrderForm.orderDate) = DATEPART(YEAR, GETDATE())
                    AND OrderForm.orderStatus = 'Done'
                GROUP BY
                    ProductInfo.prodID,
                    ProductInfo.prodName,
                    ProductPrice.price
                ORDER BY
                    total_quantity DESC;";

                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new Sale.Sale()
                    {
                        ProductItem = row["prodName"].ToString(),
                        MaxQuantity = (int)row["total_quantity"],
                        ProductID = row["prodID"].ToString(),
                        Price = Convert.ToSingle(row["price"])
                    })
                .ToList();
            }
        }


        // get specific product based this month
        public IEnumerable<Sale.Sale> GetSpecificDateSoldProductMonth(int month)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"
            SELECT
                ProductInfo.prodID,
                ProductInfo.prodName,
                COALESCE(SUM(OrderItems.quantity), 0) AS total_quantity,
                ProductPrice.price
            FROM
                ProductInfo
            LEFT JOIN
                OrderItems ON ProductInfo.prodID = OrderItems.prodID
            LEFT JOIN
                OrderForm ON OrderItems.orderID = OrderForm.orderID
            LEFT JOIN
                ProductPrice ON ProductInfo.prodID = ProductPrice.prodID
            WHERE
                MONTH(OrderForm.orderDate) = @month
                AND YEAR(OrderForm.orderDate) = YEAR(GETDATE())
                AND OrderForm.orderStatus = 'Done'
            GROUP BY
                ProductInfo.prodID,
                ProductInfo.prodName,
                ProductPrice.price
            ORDER BY
                    total_quantity DESC;";

                command.Parameters.Add("month", month);

                var products = command.ExecuteReader().Cast<IDataRecord>().Select(row => new Sale.Sale()
                {
                    ProductItem = row["prodName"].ToString(),
                    MaxQuantity = (int)row["total_quantity"],
                    ProductID = row["prodID"].ToString(),
                    Price = Convert.ToSingle(row["price"])
                }).ToList();

                // If no products are available, return a placeholder object
                if (products.Count == 0)
                {
                    return new List<Sale.Sale>
            {
                new Sale.Sale
                {
                    ProductItem = "No products available for the selected month.",
                    MaxQuantity = 0,
                    ProductID = "00000",
                    Price = 0.0f
                }
            };
                }

                return products;
            }
        }


    }
}