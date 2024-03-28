using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace MP_CS107L.App.Users
{
    public class UserRepository
    {

        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; 

        // create new user
        public void CreateUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                // Users Table
                command.CommandText =
                    $"INSERT INTO Users(username) " +
                    $"VALUES (@username) ";
                command.Parameters.AddWithValue("@username", user.Username);
                command.ExecuteNonQuery();

                // AuthUsers Table
                command.CommandText =
                    $"INSERT INTO AuthUsers(username, userPass) " +
                    $"VALUES (@username, @userPass) ";
                command.Parameters.Clear(); 
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@userPass", user.UserPass);
                command.ExecuteNonQuery();

                // InfoUsers
                command.CommandText =
                    $"INSERT INTO InfoUsers(username, fname, lname, userAddress, phoneNum, totalOrder) " +
                    $"VALUES (@username, @fname, @lname, @userAddress, @phoneNum, @totalOrder)";
                command.Parameters.Clear(); 
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@fname", user.FirstName);
                command.Parameters.AddWithValue("@lname", user.LastName);
                command.Parameters.AddWithValue("@userAddress", user.UserAddress);
                command.Parameters.AddWithValue("@phoneNum", user.PhoneNumber);
                command.Parameters.AddWithValue("@totalOrder", 1);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> LogInUser(string user)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = $"SELECT * FROM AuthUsers WHERE username = @user";
                command.Parameters.AddWithValue("user", user);

                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new User()
                    {
                        Username = (string)row["username"],
                        Password = (string)row["userPass"]
                    })
                    .ToList();
            }
        }

        public string TypeOfUser(string user)
        {
            string type = null;

            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = $"SELECT typeUser FROM InfoUsers WHERE username = @user";
                command.Parameters.AddWithValue("@user", user);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        type = reader.GetString(reader.GetOrdinal("typeUser"));
                    }
                }

                return type;
            }
        }


        // get all users
        public IEnumerable<User> GetAllUser()
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = $"SELECT * FROM InfoUsers WHERE typeUser = 'user'";

                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new User()
                    {
                        Username = (string)row["username"]
                    })
                    .ToList();
            }
        }

    }
}