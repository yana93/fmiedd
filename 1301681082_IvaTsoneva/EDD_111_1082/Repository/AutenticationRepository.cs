using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using EDD_111_1082.Entity;

namespace EDD_111_1082.Repository
{
    class AutenticationRepository
    {
        //Access to the DB that works as Log-in
        OleDbConnection conn;
        OleDbCommand cmd;

        private void ConnectTo()
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb;Persist Security Info=False;");
            cmd = conn.CreateCommand();
        }
        public AutenticationRepository()
        {
            ConnectTo();
        }
        public User Login(string username, string password)
        {
            User user = new User();
            cmd.CommandText = @"SELECT * FROM TUsers WHERE Username=@username and passwordd=@password";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            if (username != "" & password != "")
            {
                try
                {
                    conn.Open();
                    // int result = (int)cmd.ExecuteScalar();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user.ID = Convert.ToInt32(reader["ID"]);
                        user.Firstname = Convert.ToString(reader["Firstname"]);
                        user.Lastname = Convert.ToString(reader["Lastname"]);
                        user.Username = Convert.ToString(reader["Username"]);
                        user.Password = Convert.ToString(reader["Passwordd"]);
                    }
                    reader.Close();
                    if (user.ID > 0)
                    {
                        return user;
                    }

                }
                catch (OleDbException e)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
            return user = null;
        }
    }
}

