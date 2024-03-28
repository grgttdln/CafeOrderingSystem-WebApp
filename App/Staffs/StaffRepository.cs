using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace MP_CS107L.App.Staffs
{
    public class StaffRepository
    {

        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // get all staff
        public IEnumerable<Staff> GetAllStaff()
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = $"SELECT * FROM InfoUsers WHERE typeUser = 'staff'";

                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new Staff()
                    {
                        LastName = (string)row["lname"],
                        FirstName = (string)row["fname"],
                        Address = (string)row["userAddress"],
                        PhoneNumber = (string)row["phoneNum"],
                        Username = (string)row["username"]
                    })
                    .ToList();
            }
        }

        // remove a specific staff
        public void RemoveStaff(string username)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "DELETE FROM InfoUsers WHERE username = @deleteUser";
                command.Parameters.AddWithValue("deleteUser", username);
                command.ExecuteNonQuery();

                command.CommandText = "DELETE FROM AuthUsers WHERE username = @deleteUser";
                command.ExecuteNonQuery();

                command.CommandText = "DELETE FROM Users WHERE username = @deleteUser";
                command.ExecuteNonQuery();

            }
        }

        // create staff
        public void CreateStaff(Staff staff)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                // Users Table
                command.CommandText =
                   $"INSERT INTO Users(username) " +
                   $"VALUES (@username) ";
                command.Parameters.AddWithValue("@username", staff.Username);
                command.ExecuteNonQuery();

                // AuthUsers Table
                command.CommandText =
                    $"INSERT INTO AuthUsers(username, userPass) " +
                    $"VALUES (@username, @userPass) ";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@username", staff.Username);
                command.Parameters.AddWithValue("@userPass", staff.UserPass);
                command.ExecuteNonQuery();

                // InfoUsers
                command.CommandText =
                    $"INSERT INTO InfoUsers(username, fname, lname, userAddress, phoneNum, totalOrder, typeUser) " +
                    $"VALUES (@username, @fname, @lname, @userAddress, @phoneNum, @totalOrder, 'staff')";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@username", staff.Username);
                command.Parameters.AddWithValue("@fname", staff.FirstName);
                command.Parameters.AddWithValue("@lname", staff.LastName);
                command.Parameters.AddWithValue("@userAddress", staff.Address);
                command.Parameters.AddWithValue("@phoneNum", staff.PhoneNumber);
                command.Parameters.AddWithValue("@totalOrder", 0);
                command.ExecuteNonQuery();
            }
        }

    }
}