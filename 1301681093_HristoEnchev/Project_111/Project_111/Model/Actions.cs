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
        private AdminView aView = new AdminView();
        public void uAction()
        {
            Console.Clear();
            aView.FullInfo();
            Console.WriteLine("(1)Add   (2)Edit   (3)Delete");
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.D2 || cki.Key == ConsoleKey.D3)
            {
                if (cki.Key == ConsoleKey.D1)
                {
                    Console.WriteLine(" - Selected");
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

                        Console.Clear();
                        if (username != null)
                        {
                            Console.WriteLine("You added new user: {0}", username);
                        }
                        Console.WriteLine("===============================================================================");

                        command.ExecuteNonQuery();
                        connection.Close();
                        aView.FullInfo();
                    }
                    catch (OleDbException e)
                    {
                        Console.WriteLine("Error: {0}", e.Errors[0].Message);
                    }
                    uAction();

                }
                if (cki.Key == ConsoleKey.D2)
                {



                    Console.ReadKey(true);
                }

                if (cki.Key == ConsoleKey.D3)
                {
                    Console.Clear();
                    aView.FullInfo();
                    Console.WriteLine("ID: ");
                    int actionID = 0;
                    try
                    {
                        actionID = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong Input");
                        Console.ReadKey();
                        uAction();
                    }

                    User user = new User();

                    OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\usersDB.accdb;Persist Security Info=False;");
                    OleDbCommand command = new OleDbCommand("select * from users", connection);
                    OleDbCommand command2 = new OleDbCommand();
                    try
                    {
                        connection.Open();
                        OleDbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            user.ID = reader.GetInt32(0);
                            user.Username = reader.GetString(1);
                            user.Password = reader.GetString(2);
                            user.Admin = reader.GetInt32(4);
                            if (user.ID == actionID)
                            {
                                command2.CommandText = "delete from users where id=" + user.ID + ",connection";
                            }
                        }
                        
                        connection.Close();
                        reader.Close();
                        uAction();
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
