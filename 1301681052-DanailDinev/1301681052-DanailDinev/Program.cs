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
            Console.Title = "User Administration";
            Console.SetBufferSize(140, 90);
            Console.SetWindowSize(140, 35);
            myConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\data\\MyDB.accdb");
            //hacking program begins lol
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
                Console.WriteLine("4. BAN/UNBAN user");
                Console.WriteLine("5. Delete user\n");       
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
                        AddUserMenu();
                        break;
                    case 3:
                        EditUserMenu();
                        break;
                    case 4:
                        BanUserMenu();
                        break;
                    case 5:
                        DeleteUserMenu();
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
                OleDbCommand myCommand = new OleDbCommand("SELECT * FROM RegisteredUsers", myConnection);      //показжането на всички потребители
                OleDbCommand myTotalEntries = new OleDbCommand("SELECT COUNT(*) FROM RegisteredUsers", myConnection);  //общо регистрирани
                OleDbDataReader myReader = myCommand.ExecuteReader();
                Console.WriteLine("All users ({0} total):\n\nID |     Username      |      Password     |           Email             |         Realname           | Birthday |Reg.date|Confirmed|Banned\n", myTotalEntries.ExecuteScalar());
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
                    if (myReader.GetBoolean(7) == true)                      // activated 
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Yes");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }                                               
                    Console.SetCursorPosition(133, i);
                    if (myReader.GetBoolean(8) == true)                      // banned
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Yes");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }          
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

        static void AddUserMenu()
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

        static void EditUserMenu()
        {
            try
            {
                ReadAllUsers();

                // target id
                Console.Write("\n\nSelect ID you want to change ('0' - back to menu): ");
                int id = int.Parse(Console.ReadLine());
                if (id != 0)
                {
                    // show target info
                    myConnection.Open();
                    OleDbCommand myCommandSelectID = new OleDbCommand("SELECT * FROM RegisteredUsers WHERE ID=@id", myConnection);
                    myCommandSelectID.Parameters.AddWithValue("@id", id);
                    OleDbDataReader myReader = myCommandSelectID.ExecuteReader();
                    while (myReader.Read()) Console.WriteLine("\nID: {0}\n1) username: {1}\n2) password: {2}\n3) email: {3}\n4) Realname: {4}\n5) birthday: {5}\n6) active: {6}", myReader.GetInt32(0).ToString(), myReader.GetString(1), myReader.GetString(2), myReader.GetString(3), myReader.GetString(4), myReader.GetDateTime(6).ToString("yyyy-MM-dd"), myReader.GetBoolean(7));
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
                            EditUserMenu();
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
            string actionTypeString = "";  //tuk se suhranqva imeto na deistvieto 

            //Console.WriteLine("\nentered values: {0}={1} / id={2}\n", type, newValue, id);
            try
            {           
                myConnection.Open();
                if (type == "password")  //                     V  different types - different queries  V
                {
                    actionTypeString = "changed user password!";
                    OleDbCommand myCommand = new OleDbCommand("UPDATE RegisteredUsers SET `password`='" + newValue + "' WHERE ID=" + id + "", myConnection);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
                else if (type == "activated" || type == "banned")
                {
                    actionTypeString = " changed value";
                    OleDbCommand myCommand = new OleDbCommand("UPDATE RegisteredUsers SET " + type + "=" + newValue + " WHERE ID=" + id + "", myConnection);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
                else
                {
                    actionTypeString = "edited user info!";
                    OleDbCommand myCommand = new OleDbCommand("UPDATE RegisteredUsers SET " + type + "='" + newValue + "' WHERE ID=" + id + "", myConnection);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSuccesfully {0}", actionTypeString);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            catch (OleDbException e)
            {
                myConnection.Close();
                ErrorDisplay(e.Message);
            }
        }

        static void BanUserMenu()
        {
            try
            {
                bool isBanned = false;

                ReadAllUsers();

                // target id
                Console.Write("\nSelect ID you want to BAN/UNBAN ('0' back to menu): ");
                int id = int.Parse(Console.ReadLine());
                if (id != 0)
                {
                    // check if banned and shows some basic info
                    myConnection.Open();
                    OleDbCommand myCommandSelectID = new OleDbCommand("SELECT * FROM RegisteredUsers WHERE ID=@id", myConnection);
                    myCommandSelectID.Parameters.AddWithValue("@id", id);
                    OleDbDataReader myReader = myCommandSelectID.ExecuteReader();
                    while (myReader.Read())
                    {
                        if(myReader.GetBoolean(8) == true)
                        {
                            isBanned = true;
                        }
                        else
                        {
                            isBanned = false;
                        }
                        Console.Write("\nid: {0} usrname: {1} \n\n ", myReader.GetInt32(0).ToString(), myReader.GetString(1));
                    }
                    myReader.Close();
                    myConnection.Close();


                    if(isBanned == true)
                    {
                        Console.Write("Do you want to UNBAN this user? (y/n) ");
                        string choice = Console.ReadLine();
                        do
                        {
                            if(choice == "y")
                            {
                                EditUserCommand("banned", "false", id);
                                Console.ReadLine();
                                BanUserMenu();
                            } 
                            else if(choice == "n")
                            {
                                Console.WriteLine("\nYour choice was 'NO'. Press any key to continue ...");
                                Console.ReadLine();
                                BanUserMenu();
                            }
                        } while (choice == "");
                    }
                    else if(isBanned == false)
                    {
                        Console.Write("Do you want to BAN this user? (y/n) ");
                        string choice = Console.ReadLine();
                        do
                        {
                            if (choice == "y")
                            {
                                EditUserCommand("banned", "true", id);
                                Console.WriteLine("");
                                Console.ReadKey();
                                BanUserMenu();
                            }
                            else if (choice == "n")
                            {
                                Console.WriteLine("\nYour choice was 'NO'. Press any key to continue ...");
                                Console.ReadLine();
                                BanUserMenu();
                            }
                        } while (choice == "");
                    }
                }
                else { Menu(); }
            }
            catch (Exception e)
            {
                myConnection.Close();
                ErrorDisplay(e.StackTrace);
            }
        }

        static void DeleteUserMenu()
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
