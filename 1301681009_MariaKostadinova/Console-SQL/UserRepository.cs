using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_SQL
{
    public class UserRepository
    {
        public  SqlConnection conn;
       
        public SqlConnection getConnectionString()
        {
            return new SqlConnection("Data Source=ASUS\\SQLEXPRESS;Initial Catalog=DbUsers;Integrated Security=True");
        }
        
        public  void Read() 
        {
            using (SqlConnection connection = getConnectionString())
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, username, pass, email FROM Users";
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\n {0}, {1}, {2}, {3}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    }
                }
            }     
        }
       
        public void Read(int id )
        {
            using (SqlConnection connection = getConnectionString())
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id, username, pass, email FROM Users WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);                        
                    
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\n {0}, {1}, {2}, {3}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    }
                }
            }
        }

        public  void Insert(User user)
        {
            var User = user;
            try 
            {
                using (SqlConnection connection = getConnectionString()) 
                {
                    connection.Open(); 
                    using (SqlCommand command = connection.CreateCommand()) 
                    { 
                        command.CommandText = "INSERT INTO Users (Username, pass,Email) VALUES (@param1,@param2,@param3)";  

                        command.Parameters.AddWithValue("@param1", User.Username);  
                        command.Parameters.AddWithValue("@param2",User.Password);  
                        command.Parameters.AddWithValue("@param3", User.Email);  
                        command.ExecuteNonQuery(); 
                    } 
                }

            }

            catch (SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }           
        }

        public void Update(User User)
        {
            try
            {
                using (SqlConnection connection = getConnectionString())
                {

                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE Users SET username = @username, pass = @pass, email = @email WHERE id = @id";
                        command.Parameters.AddWithValue("@username", User.Username);
                        command.Parameters.AddWithValue("@pass", User.Password);
                        command.Parameters.AddWithValue("@email", User.Email);
                        command.Parameters.AddWithValue("@id", User.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
                       
        }

        public  void Delete(int ID)
        {           
            try
            {
                using (SqlConnection connection = getConnectionString())
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE FROM Users WHERE id = @id";
                        command.Parameters.AddWithValue("@id", ID);
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

