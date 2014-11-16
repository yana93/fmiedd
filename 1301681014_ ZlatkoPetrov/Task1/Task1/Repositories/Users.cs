using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task1.Entities;
using System.Data;

namespace Task1.Repositories
{
    public class Users
    {
        public List<User> GetAll()
        {
            IDbConnection conn = DB.getDB();
            conn.Open();
            List<User> UsersList = new List<User>();
            IDataReader reader = null;
            try
            {
                /* Create select command */
                IDbCommand command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM [user]";

                /* Execute command and get data */
                reader = command.ExecuteReader();
                User u;

                /* While we have records to fetch */
                while (reader.Read())
                {
                    u = new User();
                    u.ID = Convert.ToInt32(reader["id"]);
                    u.Username = Convert.ToString(reader["username"]);
                    u.Password = Convert.ToString(reader["password"]);
                    u.Email = Convert.ToString(reader["email"]);
                    UsersList.Add(u);
                }
            }
            finally
            {
                /* Always colse connection and reader */
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }

                if(conn.State == ConnectionState.Open) {
                    conn.Close();
                }
                
            }

            return UsersList;
        }

        public bool Add(User u)
        {
            IDbConnection conn = DB.getDB();
            conn.Open();
            List<User> UsersList = new List<User>();
            IDataReader reader = null;
            try
            {
                /* Create select command */
                IDbCommand command = conn.CreateCommand();
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


                /* Execute command and get data */
                if(command.ExecuteNonQuery() > 0) {
                    return true;
                }

                return false;
            }
            finally
            {
                /* Always colse connection and reader */
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }

            return false;
        }

        public User getById(int id)
        {
            IDbConnection conn = DB.getDB();
            conn.Open();
            List<User> UsersList = new List<User>();
            IDataReader reader = null;
            try
            {
                /* Create select command */
                IDbCommand command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM [user]  WHERE [id] =  @id";

                /* Create and bind paremeters */
                IDataParameter param = command.CreateParameter();
                param = command.CreateParameter();
                param.ParameterName = "id";
                param.Value = id;
                command.Parameters.Add(param);

                User u = new User();
                /* Execute command and get data */
                reader = command.ExecuteReader();
                while(reader.Read())
                {
                    u.ID = Convert.ToInt32(reader["id"]);
                    u.Username = Convert.ToString(reader["username"]);
                    u.Password = Convert.ToString(reader["password"]);
                    u.Email = Convert.ToString(reader["email"]);
                }

                return u;
            }
            finally
            {
                /* Always colse connection and reader */
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }

        public bool doesUserExistsByEmail(string email)
        {
            IDbConnection conn = DB.getDB();
            conn.Open();
            List<User> UsersList = new List<User>();
            IDataReader reader = null;
            try
            {
                /* Create select command */
                IDbCommand command = conn.CreateCommand();
                command.CommandText = "SELECT count(id) as cnt FROM [user]  WHERE [email] =  @email";

                /* Create and bind paremeters */
                IDataParameter param = command.CreateParameter();
                param = command.CreateParameter();
                param.ParameterName = "email";
                param.Value = email;
                command.Parameters.Add(param);
                reader = command.ExecuteReader();
                reader.Read();

                /* Execute command and get data */
                if (Convert.ToInt32(reader["cnt"]) > 0)
                {
                    return true;
                }

                return false;
            }
            finally
            {
                /* Always colse connection and reader */
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }

            return false;
        }

        public bool doesUserExistsByUsername(string username)
        {
            IDbConnection conn = DB.getDB();
            conn.Open();
            List<User> UsersList = new List<User>();
            IDataReader reader = null;
            try
            {
                /* Create select command */
                IDbCommand command = conn.CreateCommand();
                command.CommandText = "SELECT count(id) as cnt FROM [user]  WHERE [username] =  @username";

                /* Create and bind paremeters */
                IDataParameter param = command.CreateParameter();
                param = command.CreateParameter();
                param.ParameterName = "username";
                param.Value = username;
                command.Parameters.Add(param);
                reader = command.ExecuteReader();
                reader.Read();

                /* Execute command and get data */
                if (Convert.ToInt32(reader["cnt"]) > 0)
                {
                    return true;
                }

                return false;
            }
            finally
            {
                /* Always colse connection and reader */
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }

            return false;
        }

        public void deleteById(int id)
        {
            IDbConnection conn = DB.getDB();
            conn.Open();
            List<User> UsersList = new List<User>();
            IDataReader reader = null;
            try
            {
                /* Create select command */
                IDbCommand command = conn.CreateCommand();
                command.CommandText = "DELETE  FROM [user]  WHERE [id] =  @id";

                /* Create and bind paremeters */
                IDataParameter param = command.CreateParameter();
                param = command.CreateParameter();
                param.ParameterName = "id";
                param.Value = id;
                command.Parameters.Add(param);

                User u = new User();
                /* Execute command  */
                command.ExecuteNonQuery();

                
            }
            finally
            {
                /* Always colse connection and reader */
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }

        }

        public void Save(User u)
        {
            IDbConnection conn = DB.getDB();
            conn.Open();
            List<User> UsersList = new List<User>();
            IDataReader reader = null;
            try
            {
                /* Create select command */
                IDbCommand command = conn.CreateCommand();
                command.CommandText = "UPDATE [user] SET [username] = @username, [password] = @password, [email] = @email  WHERE [id] =  @id";

                /* Create and bind paremeters */
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
                param.Value = u.ID;
                command.Parameters.Add(param);

                /* Execute command  */
                command.ExecuteNonQuery();


            }
            finally
            {
                /* Always colse connection and reader */
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }
    }
}