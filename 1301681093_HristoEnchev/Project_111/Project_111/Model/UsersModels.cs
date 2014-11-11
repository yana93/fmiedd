using Project_111.Controllers;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_111.Model
{
    public class UsersModels
    {
        public Users CheckUserAndPassword(string username, string password)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\usersDB.accdb;Persist Security Info=False;");
            OleDbCommand command = new OleDbCommand("select * from users", connection);
            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Users user = new Users();

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
        public void FullInfo()
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\usersDB.accdb;Persist Security Info=False;");
            OleDbCommand command = new OleDbCommand("select * from users", connection);
            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Users user = new Users();
                while (reader.Read())
                {
                    Console.WriteLine("ID: {0} || UserName: {1} || Email: {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(3));
                }
                connection.Close();
                reader.Close();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }
        }
     /*   public UserID CheckUserID(int ID)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\usersDB.accdb;Persist Security Info=False;");
            OleDbCommand command = new OleDbCommand("select ID from users", connection);
            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                UserID uID = new UserID();

                while (reader.Read())
                {
                    uID.ID = reader.GetInt32(0);
                    if (uID.ID == ID)
                    {
                        return uID;
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
        */
    }
}
