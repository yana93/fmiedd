using System;
using System.Collections.Generic;
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

        //public SqlConnection getConnectionString()
        //{
        //    // Change connection string to work correctly with database
        //    //return new SqlConnection("Server=MimetoPc; Database=User; Integrated Security = true");

        //    //return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //    return new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\aspnet-webforms-crud-clientes-master (1)\aspnet-webforms-crud-clientes-master\App_Data\TrabalhoBernardiContext-20130928225426.mdf;Integrated Security=True");
        //}

        public SqlConnection getConnectionString()
        {
            // Change connection string to work correctly with database
            //return new SqlConnection("Server=MimetoPc; Database=User; Integrated Security = true");
            return new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Denis\Source\Repos\fmiedd\1301681008_YoanaSlaveva\WebFormsCrudLocalDb\WebFormsCrudLocalDb\App_Data\Crud.mdf;Integrated Security=True");
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
                        command.CommandText = "INSERT INTO Users (username, password,email) VALUES (@param1,@param2,@param3)";

                        command.Parameters.AddWithValue("@param1", User.Username);
                        command.Parameters.AddWithValue("@param2", User.Password);
                        command.Parameters.AddWithValue("@param3", User.Email);
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

        public void Update(int id, string username, string password, string email)
        {
            try
            {
                using (SqlConnection connection = getConnectionString())
                {

                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE Users SET username = @username, password = @pass, email = @email WHERE id = @id";
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@pass", password);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@id", id);
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
