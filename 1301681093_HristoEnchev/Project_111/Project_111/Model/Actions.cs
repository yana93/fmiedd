using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_111.Model
{
    class Actions
    {
        public void uAction()
        {
            UsersModels usrModel = new UsersModels();
            Console.WriteLine("(1)Add   (2)Edit   (3)Delete");           
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.D2 || cki.Key == ConsoleKey.D3)
            {
                if (cki.Key == ConsoleKey.D1)
                {
                    OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\usersDB.accdb;Persist Security Info=False;");
                    OleDbCommand command = new OleDbCommand("select * from users", connection);

                    try
                    {
                        Console.Clear();
                        Console.WriteLine("You can add new USERS");
                        Console.WriteLine("===============================================================================");
                        
                        connection.Open();
                        Console.Write("Username: ");
                        string username = Console.ReadLine().ToString();
                        Console.Write("Password: ");
                        string password = Console.ReadLine().ToString();
                        Console.Write("Email: ");
                        string Email = Console.ReadLine().ToString();
                        command.CommandText = "insert into users(userName, userPassword, Email) values('" + username + "','" + password + "','" + Email + "')";

                        command.ExecuteNonQuery();
                        connection.Close();
                        usrModel.FullInfo();
                    }
                    catch (OleDbException e)
                    {
                        Console.WriteLine("Error: {0}", e.Errors[0].Message);
                    }
                }
                if (cki.Key == ConsoleKey.D2)
                {
                    UserID TestID = new UserID();
                    Console.Clear();
                   // Console.WriteLine("(1) Edit UserName || (2) Edit Email || (3) Edit Password");
                    Console.WriteLine("Please select user");
                    Console.WriteLine("===============================================================================");
                    usrModel.FullInfo();
                    Console.WriteLine("User ID: ");
                    string test;

                    


                    OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\usersDB.accdb;Persist Security Info=False;");
                    OleDbCommand command = new OleDbCommand("select * from users", connection);

                    try
                    {
                    

                      //  connection.Close();
                      //  usrModel.FullInfo();
                    }
                    catch (OleDbException e)
                    {
                        Console.WriteLine("Error: {0}", e.Errors[0].Message);
                    }
                }

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Wrong input");
                uAction();
            }
            
        }
    }
}
