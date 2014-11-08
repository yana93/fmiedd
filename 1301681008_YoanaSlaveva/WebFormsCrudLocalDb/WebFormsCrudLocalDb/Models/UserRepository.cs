using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebFormsCrudLocalDb.Models
{
    public class UserRepository
    {
        public UserRepository()
        {
            conn = getConnectionString();
        }

        public SqlConnection conn;       
        public SqlConnection getConnectionString()
        {
            ConnectionStringSettings cm = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            return new SqlConnection(cm.ConnectionString);
        }

        public bool Insert(User user)
        {
            var User = user;
            try
            {
                using (SqlConnection connection = getConnectionString())
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO Users (username, password,email) VALUES (@username,@password,@email)";

                        command.Parameters.AddWithValue("@username", User.Username);
                        command.Parameters.AddWithValue("@password", User.Password);
                        command.Parameters.AddWithValue("@email", User.Email);
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }

            catch (SqlException e)
            {
                
            }
            return false;
        }


        public List<User> Read()
        {
            List<User> result = new List<User>();

            try
            {
                using (SqlConnection connection = conn)
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {

                        command.CommandText = "SELECT id, username, password, email FROM Users";
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var user = new User();
                            user.Id = reader.GetInt32(0);
                            user.Username = reader.GetString(1);
                            user.Password = reader.GetString(2);
                            user.Email = reader.GetString(3);

                            result.Add(user);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return result;
        }

        public User GetById(int id)
        {
            var user = new User();
            using (SqlConnection connection = conn)
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, username, password, email FROM Users WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user.Id = reader.GetInt32(0);
                        user.Username = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.Email = reader.GetString(3);
                    }
                }
            }
            return user;
        }

        public void Update(User user)
        {
            try
            {
                using (SqlConnection connection = getConnectionString())
                {

                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE Users SET username = @username, password = @pass, email = @email WHERE id = @id";
                        command.Parameters.AddWithValue("@username", user.Username);
                        command.Parameters.AddWithValue("@pass", user.Password);
                        command.Parameters.AddWithValue("@email", user.Email);
                        command.Parameters.AddWithValue("@id", user.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (SqlConnection connection = getConnectionString())
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE FROM Users WHERE id = @id";
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }

        }
    }
}
