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
            Console.WriteLine("This is main admin screen. You can Add new, edit existing  or delete user",Console.ForegroundColor = ConsoleColor.Red);
            Console.WriteLine("===============================================================================");
            Console.ForegroundColor = ConsoleColor.Gray;
            aView.FullInfo();
            Console.WriteLine("(1)Add   (2)Edit   (3)Delete                 ESC to exit");
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine("Bye");
                Console.ReadKey();
                Environment.Exit(1);
            }

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
                    Console.WriteLine(" - Selected");
                    Console.Write("ID: ");
                    int actionID = -1;
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
                            if (user.ID == actionID)
                            {
                                Console.Clear();
                                Console.WriteLine("Here you can edit users");
                                Console.WriteLine("==============================================================================");
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine("ID: {0} || UserName: {1} || Email: {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(3));
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine("-------------------------------------------------------------------------------", Console.ForegroundColor = ConsoleColor.DarkGray);
                                Console.ForegroundColor = ConsoleColor.Gray;

                                Console.WriteLine("Current USERNAME = {0}",reader.GetString(1));
                                Console.Write("New username = ", Console.BackgroundColor = ConsoleColor.DarkRed);                              
                                string newUserName = Console.ReadLine();
                                Console.BackgroundColor = ConsoleColor.Black;

                                Console.WriteLine("Current Password = {0}", reader.GetString(2));
                                Console.Write("New password = ", Console.BackgroundColor = ConsoleColor.DarkRed);
                                string newPassword = Console.ReadLine();
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine("Current Email = {0}", reader.GetString(3));
                                Console.Write("New Email = ",Console.BackgroundColor = ConsoleColor.DarkRed);
                                string newEmail = Console.ReadLine();
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Clear();
                                Console.WriteLine("Are you sure you want to update the user?");
                                Console.WriteLine("==============================================================================");
  
                                Console.WriteLine("OLDUserName: {1} || OLDEmail: {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(3));
                                Console.WriteLine("New Username: {0} || New Password: {1} || New Email: {2}",newUserName,newPassword,newEmail);
                                Console.WriteLine("(1)Yes (2)No");
                                cki = Console.ReadKey();
                                if (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.D2)
                                {
                                    if (cki.Key == ConsoleKey.D1)
                                    {
                                        try
                                        {
                                         OleDbCommand Command = new OleDbCommand("UPDATE users SET userName='" + newUserName + "' ,userPassword='" + newPassword + "' ,Email='" + newEmail +"' WHERE ID = @par1", connection);
                                            Command.Parameters.AddRange(new[] { new OleDbParameter("@par1", actionID) });
                                            Command.ExecuteNonQuery();
                                            Console.Clear();
                                            Console.WriteLine("Succssesfuly updated");
                                        }
                                        catch (OleDbException e)
                                        {
                                            Console.WriteLine("Error: {0}", e.Errors[0].Message);
                                        }   
                                    }
                                    if (cki.Key == ConsoleKey.D2)
                                    {
                                        Console.WriteLine(" - No changes made");
                                        Console.ReadKey();
                                        uAction();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Wrong input");
                                    return;
                                }
                
                            }
                        }
                        connection.Close();
                        reader.Close();
                        Console.ReadKey();
                        uAction();
                    }
                    catch (OleDbException e)
                    {
                        Console.WriteLine("Error: {0}", e.Errors[0].Message);
                    }
                }

                if (cki.Key == ConsoleKey.D3)
                {
                    OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\usersDB.accdb;Persist Security Info=False;");

                    Console.Clear();
                    Console.WriteLine("Select User ID which you want to delete", Console.ForegroundColor = ConsoleColor.Red);
                    Console.WriteLine("Or ESC to return in main screen");
                    Console.WriteLine("===============================================================================");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    aView.FullInfo();
                    User users = new User();
                    Console.Write("ID: ");
                    cki = Console.ReadKey();
                    if (cki.Key != ConsoleKey.Escape)
                    {
                        int actionID = -1;
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
                        try
                        {
                            connection.Open();

                            OleDbCommand aCommand = new OleDbCommand("DELETE FROM users WHERE ID = " + actionID, connection);
                            aCommand.ExecuteNonQuery();
                            connection.Close();
                        }
                        catch (OleDbException e)
                        {
                            Console.WriteLine("Error: {0}", e.Errors[0].Message);
                        }

                        uAction();
                        Console.ReadKey(true);
                    }
                    if (cki.Key == ConsoleKey.Escape)
                    {
                        uAction();
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
