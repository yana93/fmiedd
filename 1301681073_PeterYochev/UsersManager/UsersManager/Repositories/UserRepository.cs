using System.Collections.Generic;
using System.Data.OleDb;
using UsersManager.Entities;

namespace UsersManager.Repositories
{
    public class UsersRepository
    {
        private readonly string connectionString;

        public UsersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private void Insert(User item)
        {
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();

            using (dbConnection)
            {
                OleDbCommand command = new OleDbCommand(
                    "INSERT INTO Users([Username],[Password],[Email]) " +
                    "VALUES (@Username, @Password, @Email)",
                    dbConnection);

                command.Parameters.AddWithValue("@Username", item.Username);
                command.Parameters.AddWithValue("@Password", item.Password);
                command.Parameters.AddWithValue("@Email", item.Email);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    throw ex;
                }
            }
        }

        private void Update(User item)
        {
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            using (dbConnection)
            {
                OleDbCommand command = new OleDbCommand(
                    "UPDATE Users SET Username = @Username, `Password` = @Password, Email = @Email " +
                    "WHERE ID = @id",
                    dbConnection);

                command.Parameters.AddWithValue("@Username", item.Username);
                command.Parameters.AddWithValue("@Password", item.Password);
                command.Parameters.AddWithValue("@Email", item.Email);
                command.Parameters.AddWithValue("@id", item.ID);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    throw ex;
                }
            }
        }

        public User GetById(int id)
        {
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();

            using (dbConnection)
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM Users WHERE ID=@id", dbConnection);
                command.Parameters.AddWithValue("@id", id);

                OleDbDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.ID = (int)reader["ID"];
                        user.Username = (string)reader["Username"];
                        user.Password = (string)reader["Password"];
                        user.Email = (string)reader["Email"];

                        return user;
                    }
                }
            }

            return null;
        }

        public List<User> GetAll()
        {
            List<User> result = new List<User>();

            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();

            using (dbConnection)
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM Users", dbConnection);
                OleDbDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.ID = (int)reader["ID"];
                        user.Username = (string)reader["Username"];
                        user.Password = (string)reader["Password"];
                        user.Email = (string)reader["Email"];

                        result.Add(user);
                    }

                }
            }

            return result;
        }

        public void Delete(User item)
        {
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();

            using (dbConnection)
            {
                OleDbCommand command = new OleDbCommand("DELETE FROM Users WHERE ID=@id", dbConnection);
                command.Parameters.AddWithValue("@id", item.ID);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    throw ex;
                }

            }
        }

        public void Save(User item)
        {
            if (item.ID > 0)
            {
                Update(item);
            }
            else
            {
                Insert(item);
            }
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();

            using (dbConnection)
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM Users WHERE Username=@Username AND Password=@Password", dbConnection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                OleDbDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.ID = (int)reader["ID"];
                        user.Username = (string)reader["Username"];
                        user.Password = (string)reader["Password"];
                        user.Email = (string)reader["Email"];

                        return user;
                    }
                }
            }

            return null;
        }
    }
}
