using ProjectEED.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEED.Repository
{
    class UsersRepository
    {
        static SqlConnection connection;
        static SqlCommand command;

        private void ConnectTo()
        {
            connection = new SqlConnection(@"Data Source=(LOCAL)\SQLEXPRESS;Initial Catalog=UsersDB;Integrated Security=True");
            command = connection.CreateCommand();
        }

        public UsersRepository()
        {
            ConnectTo();

        }

        public void Insert(User user)
        {
            try
            {
                command.CommandText = "INSERT INTO [users] ([username],[password],[email],[firstname],[lastname]) VALUES ('" + user.Username + "','" + user.Password + "','" + user.Email + "','" + user.Firstname + "','" + user.Lastname + "')";
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public List<User> GetAll()
        {
            List<User> listUsers = new List<User>();

            try
            {
                command.CommandText = "SELECT * FROM users";
                command.CommandType = CommandType.Text;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();
                    user.ID = int.Parse(reader["id"].ToString());
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Firstname = reader["firstname"].ToString();
                    user.Lastname = reader["lastname"].ToString();

                    listUsers.Add(user);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return listUsers;

        }

        public void Update(User oldUser)
        {
            try
            {
                command.CommandText = "UPDATE [users] SET [username]='" + oldUser.Username + "',[password]='" + oldUser.Password + "',[email]='" + oldUser.Email + "',[firstName]='" + oldUser.Firstname + "',[LastName]='" + oldUser.Lastname + "'where [id]=" + oldUser.ID;
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        public void Delete(User user)
        {
            try
            {
                command.CommandText = "DELETE FROM [users] WHERE [id]=" + user.ID;
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        public User GetByID(int ID)
        {
            try
            {
                command.CommandText = "SELECT * FROM Users";
                command.CommandType = CommandType.Text;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();

                    user.ID = int.Parse(reader["id"].ToString());
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Firstname = reader["firstname"].ToString();
                    user.Lastname = reader["lastname"].ToString();

                    if (user.ID == ID)
                    {
                        return user;
                    }
                }
                return null;

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }
        public User GetByUsernameAndPassword(string username, string password)
        {
            try
            {
                command.CommandText = "SELECT * FROM Users";
                command.CommandType = CommandType.Text;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();

                    user.ID = int.Parse(reader["id"].ToString());
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Firstname = reader["firstname"].ToString();
                    user.Lastname = reader["lastname"].ToString();

                    if (user.Username.TrimEnd() == username && user.Password.TrimEnd() == password)
                    {
                        return user;
                    }
                }
                return null;

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }
     
    }
}
