using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDD
{
    class Program
    {
        static OleDbConnection myConnection;
        static string appHeader = "----------------------------------------------------------- USER ADMINISTRATION -----------------------------------------------------------\n";

        static void Main(string[] args)
        {
            //hacking program lol
            Console.Title = "User Administration";
            Console.SetBufferSize(140, 90);
            Console.SetWindowSize(140, 35);
            myConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\data\\MyDB.accdb");
            Menu();
        }

        static void Menu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine(appHeader);
                Console.WriteLine("1. Show all users\n");
                Console.WriteLine("2. Add user");
                Console.WriteLine("3. Edit user");
                Console.WriteLine("4. Delete user\n");
                Console.WriteLine("0. Exit application\n\n");

                Console.Write("Input: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ReadAllUsers();
                        Console.Write("\nPress any key to back to menu ...");
                        Console.ReadKey();
                        Menu();
                        break;
                    case 2:
                        AddUser();
                        break;
                    case 3:
                        EditUser();
                        break;
                    case 4:
                        DeleteUser();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Menu();
                        break;
                }
            }
            catch (Exception e)
            {
                ErrorDisplay(e.Message);
            }
        }

        static void ReadAllUsers()
        {
            try
            {
                Console.Clear();
                Console.WriteLine(appHeader);

                myConnection.Open();
                OleDbCommand myCommand = new OleDbCommand("SELECT * FROM RegisteredUsers", myConnection);
                OleDbCommand myTotalEntries = new OleDbCommand("SELECT COUNT(*) FROM RegisteredUsers", myConnection);
                OleDbDataReader myReader = myCommand.ExecuteReader();
                Console.WriteLine("All users ({0} total):\n\nID |     Username      |      Password     |           Email             |         Realname           | Birthday |Reg. date |Active|Banned\n", myTotalEntries.ExecuteScalar());
                int i = Console.CursorTop;
                while (myReader.Read())
                {
                    Console.SetCursorPosition(0, i);
                    Console.WriteLine(myReader.GetInt32(0).ToString());     // ID
                    Console.SetCursorPosition(4, i);
                    Console.WriteLine(myReader.GetString(1));               // username
                    Console.SetCursorPosition(24, i);
                    Console.WriteLine(myReader.GetString(2));               // passwd
                    Console.SetCursorPosition(44, i);
                    Console.WriteLine(myReader.GetString(3));               // email
                    Console.SetCursorPosition(74, i);
                    Console.WriteLine(myReader.GetString(4));               // realname
                    Console.SetCursorPosition(103, i);
                    Console.WriteLine(myReader.GetDateTime(5).ToString("yyyy-MM-dd"));    //bday
                    Console.SetCursorPosition(114, i);
                    Console.WriteLine(myReader.GetDateTime(6).ToString("yyyy-MM-dd"));    //regdate
                    Console.SetCursorPosition(126, i);
                    Console.WriteLine(myReader.GetBoolean(7));              // acttivatedd
                    Console.SetCursorPosition(132, i);
                    Console.WriteLine(myReader.GetBoolean(8));              // banned
                    i++;

                }
                myReader.Close();
                myConnection.Close();
            }
            catch (OleDbException e)
            {
                myConnection.Close();
                ErrorDisplay(e.Message);
            }
        }

        static void AddUser()
        {
            try
            {
                string newUserName, newPassword, newEmail, newRealname, newBirthday, isActivatedInput;
                bool isActivated = false;

                Console.Clear();
                Console.WriteLine(appHeader);
                Console.WriteLine("Add new user \n\n");

                Console.Write("Username (only letters and numbers): ");
                do { newUserName = Console.ReadLine(); } while (newUserName == "");    // fast check for empty input

                Console.Write("Password (only letters and numbers): ");
                do { newPassword = Console.ReadLine(); } while (newPassword == "");

                Console.Write("Email: ");
                do { newEmail = Console.ReadLine(); } while (newEmail == "");

                Console.Write("Name: ");
                do { newRealname = Console.ReadLine(); } while (newRealname == "");

                Console.Write("Birthday (YYYY-MM-DD): ");
                do { newBirthday = Console.ReadLine(); } while (newBirthday == "");

                Console.Write("Active (y/n): ");
                isActivatedInput = Console.ReadLine();
                do
                {
                    if (isActivatedInput == "y")
                        isActivated = true;
                    else if (isActivatedInput == "n")
                        isActivated = false;
                } while (isActivatedInput == "");

                try
                {
                    myConnection.Open();
                    OleDbCommand myCommand = new OleDbCommand("INSERT INTO RegisteredUsers (username, `password`, email, realname, birthday, dateregistered, activated, banned) values (@newUserName, @newPassword, @newEmail, @newRealname, @birthday, NOW(), @isActivated, FALSE)", myConnection);
                    myCommand.Parameters.AddWithValue("@newUserName", newUserName);
                    myCommand.Parameters.AddWithValue("@newPassword", newPassword);
                    myCommand.Parameters.AddWithValue("@newEmail,", newEmail);
                    myCommand.Parameters.AddWithValue("@newRealname", newRealname);
                    myCommand.Parameters.AddWithValue("@newBirthday", newBirthday);
                    myCommand.Parameters.AddWithValue("@isActivated", isActivated);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nSuccesfully added user!\n\nPress any key to back to menu ...");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                    Menu();
                }
                catch (OleDbException e)
                {
                    myConnection.Close();
                    ErrorDisplay(e.Message);
                }
            }
            catch (Exception e)
            {
                ErrorDisplay(e.Message);
            }
        }

        static void EditUser()
        {
            try
            {
                ReadAllUsers();

                // target id
                Console.Write("\nSelect ID you want to change ('0' - back to menu): ");
                int id = int.Parse(Console.ReadLine());
                if (id != 0)
                {
                    // show target info
                    myConnection.Open();
                    OleDbCommand myCommandSelectID = new OleDbCommand("SELECT * FROM RegisteredUsers WHERE ID=@id", myConnection);
                    myCommandSelectID.Parameters.AddWithValue("@id", id);
                    OleDbDataReader myReader = myCommandSelectID.ExecuteReader();
                    while (myReader.Read()) Console.WriteLine("\nID: {0}\n1) username: {1}\n2) password: {2}\n3) email: {3}\n4) realname: {4}\n5) birthday: {5}\n6) active: {6}\n7) banned: {7}", myReader.GetInt32(0).ToString(), myReader.GetString(1), myReader.GetString(2), myReader.GetString(3), myReader.GetString(4), myReader.GetDateTime(6).ToString("yyyy-MM-dd"), myReader.GetBoolean(7), myReader.GetBoolean(8));
                    myReader.Close();
                    myConnection.Close();

                    // pick value to change
                    int choice;
                    string newValue;
                    do
                    {
                        Console.Write("\nValue you want to change (write digit or '0' to change id): ");
                        choice = int.Parse(Console.ReadLine());

                        if (choice == 1)
                        {
                            Console.Write("\nWrite new username: ");
                            do { newValue = Console.ReadLine(); } while (newValue == "");
                            EditUserCommand("username", newValue, id);
                        }
                        else if (choice == 2)
                        {
                            Console.Write("\nWrite new password: ");
                            do { newValue = Console.ReadLine(); } while (newValue == "");
                            EditUserCommand("password", newValue, id);
                        }
                        else if (choice == 3)
                        {
                            Console.Write("\nWrite new email: ");
                            do { newValue = Console.ReadLine(); } while (newValue == "");
                            EditUserCommand("email", newValue, id);
                        }
                        else if (choice == 4)
                        {
                            Console.Write("\nWrite new name: ");
                            do { newValue = Console.ReadLine(); } while (newValue == "");
                            EditUserCommand("realname", newValue, id);
                        }
                        else if (choice == 5)
                        {
                            Console.Write("\nWrite new birthday(yyyy-mm-dd): ");
                            do { newValue = Console.ReadLine(); } while (newValue == "");
                            EditUserCommand("birthday", newValue, id);
                        }
                        else if (choice == 6)
                        {
                            Console.Write("\nIs user activated by email? (true/false): ");
                            do { newValue = Console.ReadLine(); } while (newValue == "");
                            EditUserCommand("activated", newValue, id);
                        }
                        else if (choice == 7)
                        {
                            Console.Write("\nIs user banned? (true/false): ");
                            do { newValue = Console.ReadLine(); } while (newValue == "");
                            EditUserCommand("banned", newValue, id);
                        }
                        else if (choice == 0)
                        {
                            EditUser();
                            Console.ReadKey();
                        }
                    } while (choice != 0);
                }
                else { Menu(); }
            }
            catch (Exception e)
            {
                myConnection.Close();
                ErrorDisplay(e.Message);
            }
        }

        static void EditUserCommand(string type, string newValue, int id)
        {
            //Console.WriteLine("\nentered values: {0}={1} / id={2}\n", type, newValue, id);
            try
            {
                myConnection.Open();
                if (type == "password")  //                     V  different types - different queries  V
                {
                    OleDbCommand myCommand = new OleDbCommand("UPDATE RegisteredUsers SET `password`='" + newValue + "' WHERE ID=" + id + "", myConnection);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
                else if (type == "activated")
                {
                    OleDbCommand myCommand = new OleDbCommand("UPDATE RegisteredUsers SET " + type + "=" + newValue + " WHERE ID=" + id + "", myConnection);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }

                else if (type == "banned")
                {
                    OleDbCommand myCommand = new OleDbCommand("UPDATE RegisteredUsers SET " + type + "=" + newValue + " WHERE ID=" + id + "", myConnection);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
                else
                {
                    OleDbCommand myCommand = new OleDbCommand("UPDATE RegisteredUsers SET " + type + "='" + newValue + "' WHERE ID=" + id + "", myConnection);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSuccesfully edited user!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            catch (OleDbException e)
            {
                myConnection.Close();
                ErrorDisplay(e.Message);
            }
        }

        static void DeleteUser()
        {
            try
            {
                ReadAllUsers();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nID you want to delete ('0' - back to menu): ");
                int choice = int.Parse(Console.ReadLine());

                if (choice != 0)
                {
                    try
                    {
                        myConnection.Open();
                        OleDbCommand myCommand = new OleDbCommand("DELETE FROM RegisteredUsers WHERE ID = @id", myConnection);
                        myCommand.Parameters.AddWithValue("@id", choice);
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nSuccesfully deleted user!\n\nPress any key to back to menu ...");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadKey();
                        Menu();
                    }
                    catch (OleDbException e)
                    {
                        myConnection.Close();
                        ErrorDisplay(e.Message);
                    }
                }
                else { Menu(); }
            }
            catch (Exception e)
            {
                ErrorDisplay(e.Message);
            }
        }

        static void ErrorDisplay(string e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nApplication error: {0}\n\nPress any key to back to menu ...", e);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
            Menu();
        }
    }
}
