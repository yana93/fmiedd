using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;

namespace task1
{
    class Repo
    {
        public static SqlCeConnection Connection;

        public Repo()
        {

            var appSettings = System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            Connection = new SqlCeConnection();
            Connection.ConnectionString = appSettings;

        }

        public List<User> ListUsers()
        {
            List<User> Users = new List<User>();
            Connection.Open();

            SqlCeCommand command = Connection.CreateCommand();

            command.CommandText = "SELECT * FROM [users]";
            SqlCeDataReader reader = command.ExecuteReader();
            Console.Clear();
            User u;
            while (reader.Read())
            {
                u = new User();
                u.id = Convert.ToInt32(reader["id"]);
                u.username = reader["username"].ToString();
                u.email = reader["email"].ToString();
                u.password = reader["password"].ToString();
                Users.Add(u);
            }

            Connection.Close();

            return Users;
        }

        public int AddUser(string username, string password, string email)
        {
            Connection.Open();

            SqlCeCommand command = Connection.CreateCommand();

            command.CommandText = "INSERT INTO [users] (username,password,email) VALUES (@username, @password ,@email)";

            SqlCeParameter param = command.CreateParameter();

            param.ParameterName = "username";
            param.Value = username;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "password";
            param.Value = password;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "email";
            param.Value = email;
            command.Parameters.Add(param);

            int res = command.ExecuteNonQuery();
            Connection.Close();

            return res;
        }

        public int DeleteUser(int id)
        {
            Connection.Open();

            SqlCeCommand command = Connection.CreateCommand();

            command.CommandText = "DELETE FROM [users] WHERE id = @id";

            SqlCeParameter param = command.CreateParameter();

            param.ParameterName = "id";
            param.Value = id;
            command.Parameters.Add(param);

            int res = command.ExecuteNonQuery();
            Connection.Close();
            return res;
        }

        public int UpdateUser(int id, string username, string password, string email)
        {
            Connection.Open();

            SqlCeCommand comm = Connection.CreateCommand();

            comm.CommandText = "UPDATE [users] SET username = @username, password=@password, email = @email WHERE id = @id";

            SqlCeParameter param;

            param = comm.CreateParameter();
            param.ParameterName = "username";
            param.Value = username;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "password";
            param.Value = password;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "email";
            param.Value = email;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "id";
            param.Value = id;
            comm.Parameters.Add(param);

            int res = comm.ExecuteNonQuery();
            Connection.Close();

            return res;
        }
    }
}
