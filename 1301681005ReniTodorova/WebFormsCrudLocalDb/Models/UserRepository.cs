using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebFormsCrudAccess.Models
{
    public class UserRepository
    {
        public UserRepository()
        {
            conn = getConnectionString();
        }

        public IDbConnection conn;
        public IDbConnection getConnectionString()
        {
            ConnectionStringSettings cm = ConfigurationManager.ConnectionStrings["myConnection"];
            IDbConnection Conn = new OleDbConnection(cm.ConnectionString);
            return Conn;
        }

        public bool Insert(User u)
        {            
            try
            {
                using (IDbConnection connection = getConnectionString())
                {
                    connection.Open();
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO [user] ([username], [password], [email]) VALUES (@username, @password,@email)";

                        /* Create and bind paremeters */
                        IDataParameter param = command.CreateParameter();

                        param.ParameterName = "username";
                        param.Value = u.Username;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "password";
                        param.Value = u.Password;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "email";
                        param.Value = u.Email;
                        command.Parameters.Add(param);

                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }

            catch (Exception e)
            {
                e.Message.ToString();
            }
            return false;
        }


        public List<User> Read()
        {
            List<User> result = new List<User>();

            try
            {
                using (IDbConnection connection = conn)
                {
                    connection.Open();
                    using (IDbCommand command = connection.CreateCommand())
                    {
                       
                        command.CommandText = "SELECT * FROM [user]";
                        IDataReader reader = null;
                        reader = command.ExecuteReader();                       
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
            using (IDbConnection connection = conn)
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [id], [username], [password], [email] FROM [User] WHERE [id] = @id";

                    IDataParameter param = command.CreateParameter();

                    param.ParameterName = "id";
                    param.Value = id;
                    command.Parameters.Add(param);

                    IDataReader reader = null;
                    reader = command.ExecuteReader();
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

        public void Update(User u)
        {
            try
            {
                using (IDbConnection connection = getConnectionString())
                {

                    connection.Open();
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        
                        command.CommandText = "UPDATE [user] SET [username] = @username, [password] = @password, [email] = @email  WHERE [id] =  @id";

                      
                        IDataParameter param;

                        param = command.CreateParameter();
                        param.ParameterName = "username";
                        param.Value = u.Username;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "password";
                        param.Value = u.Password;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "email";
                        param.Value = u.Email;
                        command.Parameters.Add(param);

                        param = command.CreateParameter();
                        param.ParameterName = "id";
                        param.Value = u.Id;
                        command.Parameters.Add(param);
                      
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
                using (IDbConnection connection = getConnectionString())
                {
                    connection.Open();
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE FROM [User] WHERE [id] = @id";
                        IDataParameter param;

                        param = command.CreateParameter();
                        param.ParameterName = "id";
                        param.Value = id;
                        command.Parameters.Add(param);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

        }
    }
}
