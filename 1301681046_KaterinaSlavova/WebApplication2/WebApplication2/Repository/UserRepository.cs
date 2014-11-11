using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Web;

namespace WebApplication2.Repository
{
    public class UserRepository
    {
        static SqlCeConnection connection;
        static SqlCeCommand command;

        private void ConnectTo()
        {
            connection = new SqlCeConnection(@"Data Source=C:\Users\Katerina\documents\visual studio 2012\Projects\WebApplication2\WebApplication2\App_Data\users.sdf");
            command = connection.CreateCommand();
        }

        public UserRepository()
        {
            ConnectTo();
        }

        public void Insert(User user)
        {
            try
            {
                command.CommandText = "INSERT INTO [Users] ([username], [password], [email], [firstname], [lastname]) VALUES('" + user.Username + "','" + user.Password + "','" + user.Email + "','" + user.Firstname + "','" + user.Lastname + "')";
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();
            }
            catch(SqlCeException ex)
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
                command.CommandText = "SELECT * FROM Users";
                command.CommandType = CommandType.Text;
                connection.Open();

                SqlCeDataReader reader = command.ExecuteReader();

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
            catch (SqlCeException ex)
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
            public void Update( User oldUser)
            {
                 try
            {
                command.CommandText = "UPDATE [Users] SET [username]='" + oldUser.Username + "',[password]='" + oldUser.Password + "',[email]='" + oldUser.Email + "',[firstname]='" + oldUser.Firstname + "',[lastname]='" + oldUser.Lastname + "'where [id]=" + oldUser.ID;
                     command.CommandType = CommandType.Text;
                     connection.Open();

                     command.ExecuteNonQuery();
            }
            catch(SqlCeException ex)
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
                command.CommandText = "DELETE FROM [Users] WHERE [id]=" + user.ID;
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

                connection.Open();

                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();

                    user.ID = int.Parse(reader["id"].ToString());
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Firstname = reader["firstName"].ToString();
                    user.Lastname = reader["lastName"].ToString();

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

                SqlCeDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();

                    user.ID = int.Parse(reader["id"].ToString());
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Firstname = reader["firstName"].ToString();
                    user.Lastname = reader["lastName"].ToString();

                    if (user.Username==username && user.Password==password)
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