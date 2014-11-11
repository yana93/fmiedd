using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_111.Model
{
    class LogCheck
    {
        public User CheckUserAndPassword(string username, string password)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\usersDB.accdb;Persist Security Info=False;");
            OleDbCommand command = new OleDbCommand("select * from users", connection);
            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                User user = new User();

                while (reader.Read())
                {
                    user.ID = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.Admin = reader.GetInt32(4);
                    if (user.Username == username && user.Password == password)
                    {
                        return user;
                    }
                }
                connection.Close();
                reader.Close();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }
            return null;
        }
    }
}
