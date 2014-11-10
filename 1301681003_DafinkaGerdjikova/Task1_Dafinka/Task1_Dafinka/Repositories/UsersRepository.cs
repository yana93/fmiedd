using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_Dafinka.Entities;

namespace Task1_Dafinka.Repositories
{
    public class UsersRepository
    {
        public IDbConnection conn = null;

        public UsersRepository()
        {
            this.conn = new OleDbConnection();
            this.conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=task1.mdb;";
        }

        public User GetByUserNameandPassword(string username, string password)
        {
            User user = null;


            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT*FROM[Users] WHERE Username=@C AND Password=@Password";

            IDataParameter param = cmd.CreateParameter();
            param.ParameterName = "@Username";
            param.Value = username;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@Password";
            param.Value = password;
            cmd.Parameters.Add(param);

            try
            {
                conn.Open();
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User();
                    user.ID = (int)reader["ID"];
                    user.FirstName = (string)reader["FirstName"];
                    user.LastName = (string)reader["LastName"];
                    user.Username = (string)reader["Username"];
                    user.Password = (string)reader["Password"];
                    user.Email = (string)reader["Email"];
                }
            }
            finally
            {
                conn.Close();
            }
            return user;
        }
        public List<User> GetAll()
        {

            List<User> result = new List<User>();

            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM [users]";

            try
            {
                conn.Open();
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();

                    user.ID = (int)reader["ID"];
                    user.FirstName = (string)reader["FirstName"];
                    user.LastName = (string)reader["LastName"];
                    user.Username = (string)reader["Username"];
                    user.Password = (string)reader["Password"];
                    user.Email = (string)reader["Email"];
                    result.Add(user);
                }
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public void EditUser(User item)
        {
            IDbCommand cmd = this.conn.CreateCommand();
            if (item.ID > 0)
            {
                cmd.CommandText = @"
UPDATE Users SET
[FirstName]=@FirstName,
[LastName]=@LastName,
[Username]=@Username,
[Password]=@Password,
[Email]=@Email
WHERE
[ID]=@ID
";
                IDataParameter param = cmd.CreateParameter();
                param.ParameterName = "@FirstName";
                param.Value = item.FirstName;
                cmd.Parameters.Add(param);

                param = cmd.CreateParameter();
                param.ParameterName = "@LastName";
                param.Value = item.LastName;
                cmd.Parameters.Add(param);

                param = cmd.CreateParameter();
                param.ParameterName = "@Username";
                param.Value = item.Username;
                cmd.Parameters.Add(param);

                param = cmd.CreateParameter();
                param.ParameterName = "@Password";
                param.Value = item.Password;
                cmd.Parameters.Add(param);

                param = cmd.CreateParameter();
                param.ParameterName = "@Email";
                param.Value = item.Email;
                cmd.Parameters.Add(param);

                param = cmd.CreateParameter();
                param.ParameterName = "@ID";
                param.Value = item.ID;
                cmd.Parameters.Add(param);
            }
            else
            {
                cmd.CommandText = @"
INSERT INTO Users
(
[FirstName],
[LastName],
[Username],
[Password],
[Email]
)
VALUES(
@FirstName,
@LastName,
@Username,
@Password,
@Email
)";
                IDataParameter param = cmd.CreateParameter();
                param.ParameterName = "@FirstName";
                param.Value = item.FirstName;
                cmd.Parameters.Add(param);

                param = cmd.CreateParameter();
                param.ParameterName = "@LastName";
                param.Value = item.LastName;
                cmd.Parameters.Add(param);

                param = cmd.CreateParameter();
                param.ParameterName = "@Username";
                param.Value = item.Username;
                cmd.Parameters.Add(param);

                param = cmd.CreateParameter();
                param.ParameterName = "@Password";
                param.Value = item.Password;
                cmd.Parameters.Add(param);

                param = cmd.CreateParameter();
                param.ParameterName = "@Email";
                param.Value = item.Email;
                cmd.Parameters.Add(param);
            }
            try
            {
                this.conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                this.conn.Close();
            }
        }

        public void Delete(User item)
        {

            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
DELETE FROM[Users]
WHERE
ID=@ID
";
            IDataParameter param = cmd.CreateParameter();
            param.ParameterName = "@ID";
            param.Value = item.ID;
            cmd.Parameters.Add(param);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
